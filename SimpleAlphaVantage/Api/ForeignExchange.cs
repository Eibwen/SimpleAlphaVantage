using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantage.Api
{
    public class ForeignExchange : BaseEndpointParameters
    {
        public ForeignExchange(string apiKey, GenericApiClient apiClient = null)
            : base(apiKey, apiClient)
        {
        }

        public async Task<CurrencyExchangeRate> CurrencyExchangeRate(string fromCurrency, string toCurrency)
        {
            var function = ApiFunction.CURRENCY_EXCHANGE_RATE;

            return await ApiClient.SendGetAsync<CurrencyExchangeRate>(BuildUri(function), new Dictionary<string, string>
            {
                {"from_currency", fromCurrency},
                {"to_currency", toCurrency}
            });
        }
    }
}