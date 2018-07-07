using Newtonsoft.Json;
// ReSharper disable InconsistentNaming

namespace SimpleAlphaVantage.ResponseModels
{
    public class DigitalCurrencyFullData
    {
        [JsonProperty("1a. open")]
        public decimal Open { get; set; }
        [JsonProperty("1b. open (USD)")]
        public decimal OpenUSD { get; set; }
        [JsonProperty("2a. high")]
        public decimal High { get; set; }
        [JsonProperty("2b. high (USD)")]
        public decimal HighUSD { get; set; }
        [JsonProperty("3a. low")]
        public decimal Low { get; set; }
        [JsonProperty("3b. low (USD)")]
        public decimal LowUSD { get; set; }
        [JsonProperty("4a. close")]
        public decimal Close { get; set; }
        [JsonProperty("4b. close (USD)")]
        public decimal CloseUSD { get; set; }
        [JsonProperty("5. volume")]
        public decimal Volume { get; set; }
        [JsonProperty("6. market cap (USD)")]
        public decimal MarketCapUSD { get; set; }
    }
}