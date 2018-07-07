using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels
{
    public class DigitalCurrencyIntraday : BaseResposeData<DigitalCurrencySpotData>
    {
        
    }

    public class DigitalCurrencySpotData : ParenthesesCurrencyBase
    {
        [JsonProperty("1a. price")]
        public decimal Price { get; set; }
        [JsonProperty("1b. price (USD)")]
        // ReSharper disable once InconsistentNaming
        public decimal PriceUSD { get; set; }
        [JsonProperty("2. volume")]
        public decimal Volume { get; set; }
        [JsonProperty("3. market cap (USD)")]
        public decimal MarketCap { get; set; }
    }
}