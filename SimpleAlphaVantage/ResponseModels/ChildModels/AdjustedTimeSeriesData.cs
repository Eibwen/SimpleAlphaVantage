using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels
{
    public class AdjustedTimeSeriesData
    {
        [JsonProperty("1. open")]
        public decimal Open { get; set; }

        [JsonProperty("2. high")]
        public decimal High { get; set; }

        [JsonProperty("3. low")]
        public decimal Low { get; set; }

        [JsonProperty("4. close")]
        public decimal Close { get; set; }

        [JsonProperty("5. adjusted close")]
        public decimal AdjustedClose { get; set; }

        [JsonProperty("6. volume")]
        public long Volume { get; set; }

        [JsonProperty("7. dividend amount")]
        public decimal DividendAmount { get; set; }

        [JsonProperty("8. split coefficient")]
        public decimal SplitCoefficient { get; set; }
    }
}