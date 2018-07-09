using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels.TechnicalIndicatorModels
{
    public class BollingerBands
    {
        [JsonProperty("Real Upper Band")]
        public decimal RealUpperBand { get; set; }
        [JsonProperty("Real Lower Band")]
        public decimal RealLowerBand { get; set; }
        [JsonProperty("Real Middle Band")]
        public decimal RealMiddleBand { get; set; }
    }
}