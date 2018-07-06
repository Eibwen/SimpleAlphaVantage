using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels
{
    public class CurrencyExchangeRate
    {
        [JsonProperty("Realtime Currency Exchange Rate")]
        public ExchangeRateData Data { get; set; }
    }

    public class ExchangeRateData
    {
        [JsonProperty("1. From_Currency Code")]
        public string FromCurrencyCode { get; set; }
        [JsonProperty("2. From_Currency Name")]
        public string FromCurrencyName { get; set; }
        [JsonProperty("3. To_Currency Code")]
        public string ToCurrencyCode { get; set; }
        [JsonProperty("4. To_Currency Name")]
        public string ToCurrencyName { get; set; }
        [JsonProperty("5. Exchange Rate")]
        public string ExchangeRate { get; set; }
        [JsonProperty("6. Last Refreshed")]
        public string LastRefreshed { get; set; }
        [JsonProperty("7. Time Zone")]
        public string TimeZone { get; set; }
    }
}