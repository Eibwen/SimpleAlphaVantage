using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleAlphaVantage.Utilities
{
    public class GenericApiClient
    {
        private readonly HttpClient _client = new HttpClient();

        public GenericApiClient(Action<HttpClient> confgiureClient)
        {
            confgiureClient(_client);
        }

        internal GenericApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<TResponse> SendGetAsync<TRequestParams, TResponse>(Uri requestUri, TRequestParams parameters)
            where TRequestParams : IRequestParams
        {
            return await SendAsync<TRequestParams, TResponse>(HttpMethod.Get, requestUri, parameters);
        }

        public async Task<TResponse> SendAsync<TRequestParams, TResponse>(HttpMethod method, Uri requestUri, TRequestParams parameters)
            where TRequestParams : IRequestParams
        {
            var dictParams = parameters.ToDictionary();
            var paramsString = string.Join("&", dictParams.Select(kvp => $"{WebUtility.UrlEncode(kvp.Key)}={WebUtility.UrlEncode(kvp.Value)}"));
            var fullUri = AppendParams(requestUri, paramsString);

            var req = new HttpRequestMessage(method, fullUri);

            var res = await _client.SendAsync(req);
            res.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<TResponse>(await res.Content.ReadAsStringAsync());
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