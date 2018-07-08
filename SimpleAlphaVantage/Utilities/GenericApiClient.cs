using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.SerializationClasses;

namespace SimpleAlphaVantage.Utilities
{
    public class GenericApiClient
    {
        private readonly HttpClient _client = new HttpClient();

        public GenericApiClient(Action<HttpClient> confgiureClient = null, bool strictDeserialization = true)
        {
            confgiureClient?.Invoke(_client);

            //TODO well this makes this NOT generic... have this passed in, and for my library inherid from generic one
            JsonSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = strictDeserialization ? MissingMemberHandling.Error : MissingMemberHandling.Ignore
            };
            JsonSettings.Converters.Add(new MetadataJsonConverter());
            //TODO do some sort of scan to find all of these:
            JsonSettings.Converters.Add(new BaseResposeDataJsonConverter<TimeSeriesData>());
            JsonSettings.Converters.Add(new BaseResposeDataJsonConverter<AdjustedTimeSeriesData>());
            JsonSettings.Converters.Add(new BaseResposeDataJsonConverter<DigitalCurrencySpotData>());
            JsonSettings.Converters.Add(new BaseResposeDataJsonConverter<DigitalCurrencyFullData>());
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

            if (baseUri.Query != null && baseUri.Query.Length > 1)
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