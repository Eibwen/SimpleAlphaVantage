using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantage.Api
{
    public class ForeignExchange
    {
        private readonly string _apiKey;
        private readonly GenericApiClient _apiClient;

        private readonly DataFormat _dataFormat = DataFormat.json;

        public ForeignExchange(string apiKey, GenericApiClient apiClient = null)
        {
            _apiKey = apiKey;
            _apiClient = apiClient ?? new GenericApiClient(ConfigureClient);
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


        //TODO is the above a good candidate for an abstract class members?





        public async Task<CurrencyExchangeRate> CurrencyExchangeRate(string fromCurrency, string toCurrency)
        {
            var function = ApiFunction.CURRENCY_EXCHANGE_RATE;

            return await _apiClient.SendGetAsync<CurrencyExchangeRate>(BuildUri(function), new Dictionary<string, string>
            {
                {"from_currency", fromCurrency},
                {"to_currency", toCurrency}
            });
        }
    }
}