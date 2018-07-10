using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.ResponseModels.TechnicalIndicatorModels;
using SimpleAlphaVantage.Utilities.SerializationClasses;

namespace SimpleAlphaVantage.Utilities
{
    public class GenericApiClient
    {
        private readonly HttpClient _client = new HttpClient();

        public GenericApiClient(Action<HttpClient> configureClient = null, bool strictDeserialization = true)
        {
            configureClient?.Invoke(_client);

            //TODO well this makes this NOT generic... have this passed in, and for my library inherit from generic one
            JsonSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = strictDeserialization ? MissingMemberHandling.Error : MissingMemberHandling.Ignore
            };
            JsonSettings.Converters.Add(new MetadataJsonConverter());
            //TODO do some sort of scan to find all of these:
            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<TimeSeriesData>());
            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<AdjustedTimeSeriesData>());
            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<DigitalCurrencySpotData>());
            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<DigitalCurrencyFullData>());

            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<MesaAdaptiveMovingAverage>());
            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<Macd>());
            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<StochasticSlow>());
            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<StochasticFast>());
            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<Aroon>());
            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<BollingerBands>());
            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<HilbertTransformSine>());
            JsonSettings.Converters.Add(new BaseResponseDataJsonConverter<HilbertTransformPhasor>());

            JsonSettings.Converters.Add(new TechnicalIndicatorSingleValueJsonConverter());
            JsonSettings.Converters.Add(new ParenthesesCurrencyPropertyJsonConverter());
        }

        protected JsonSerializerSettings JsonSettings { get; set; }

        internal GenericApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<TResponse> SendGetAsync<TRequestParams, TResponse>(Uri requestUri, TRequestParams parameters)
            where TRequestParams : IRequestParams
        {
            return await SendAsync<TRequestParams, TResponse>(HttpMethod.Get, requestUri, parameters);
        }

        public async Task<TResponse> SendGetAsync<TResponse>(Uri requestUri, Dictionary<string, string> parameters)
        {
            return await SendAsync<TResponse>(HttpMethod.Get, requestUri, parameters);
        }

        public async Task<TResponse> SendAsync<TRequestParams, TResponse>(HttpMethod method, Uri requestUri, TRequestParams parameters)
            where TRequestParams : IRequestParams
        {
            return await SendAsync<TResponse>(method, requestUri, parameters.ToDictionary());
        }

        public async Task<TResponse> SendAsync<TResponse>(HttpMethod method, Uri requestUri, Dictionary<string, string> parameters)
        {
            var paramsString = string.Join("&", parameters.Select(kvp => $"{WebUtility.UrlEncode(kvp.Key)}={WebUtility.UrlEncode(kvp.Value)}"));
            var fullUri = AppendParams(requestUri, paramsString);

            var req = new HttpRequestMessage(method, fullUri);

            var res = await _client.SendAsync(req);
            res.EnsureSuccessStatusCode();

            return DeserializeWithSettings<TResponse>(await res.Content.ReadAsStringAsync());
        }

        internal T DeserializeWithSettings<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSettings);
        }

        internal object DeserializeWithSettings(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type, JsonSettings);
        }

        private Uri AppendParams(Uri original, string toAppend)
        {
            UriBuilder baseUri = new UriBuilder(original);

            if (baseUri.Query.Length > 1)
                baseUri.Query = baseUri.Query.Substring(1) + "&" + toAppend;
            else
                baseUri.Query = toAppend;

            return baseUri.Uri;
        }
    }

    public interface IRequestParams
    {
        Dictionary<string, string> ToDictionary();
    }
}