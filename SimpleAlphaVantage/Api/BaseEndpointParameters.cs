using System;
using System.Net.Http;
using SimpleAlphaVantage.Enums;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantage.Api
{
    public abstract class BaseEndpointParameters
    {
        private readonly string _apiKey;
        protected readonly GenericApiClient ApiClient;

        private readonly DataFormat _dataFormat = DataFormat.json;

        protected BaseEndpointParameters(string apiKey, GenericApiClient apiClient = null)
        {
            _apiKey = apiKey;
            ApiClient = apiClient ?? new GenericApiClient(ConfigureClient);
        }

        protected void ConfigureClient(HttpClient client)
        {
            //client.DefaultRequestHeaders
            //    .Accept
            //    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected Uri BuildUri(ApiFunction function)
        {
            return new Uri($"https://www.alphavantage.co/query?function={function}&apikey={_apiKey}&datatype={_dataFormat}");
        }
    }
}