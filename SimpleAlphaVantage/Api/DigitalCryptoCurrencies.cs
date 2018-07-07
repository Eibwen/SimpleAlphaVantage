using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantage.Api
{
    public class DigitalCryptoCurrencies : BaseEndpointParameters
    {
        public DigitalCryptoCurrencies(string apiKey, GenericApiClient apiClient = null)
            : base(apiKey, apiClient)
        {
        }

        public async Task<DigitalCurrencyIntraday> DigitalCurrencyIntraday(string symbol, string market)
        {
            var function = ApiFunction.DIGITAL_CURRENCY_INTRADAY;

            return await ApiClient.SendGetAsync<DigitalCurrencyIntraday>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"market", market}
            });
        }

        public async Task<DigitalCurrencyDaily> DigitalCurrencyDaily(string symbol, string market)
        {
            var function = ApiFunction.DIGITAL_CURRENCY_DAILY;

            return await ApiClient.SendGetAsync<DigitalCurrencyDaily>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"market", market}
            });
        }
    }
}