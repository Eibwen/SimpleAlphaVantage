using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels.TechnicalIndicatorModels
{
    public class MesaAdaptiveMovingAverage
    {
        [JsonProperty("MAMA")]
        public decimal MAMA { get; set; }
        [JsonProperty("FAMA")]
        public decimal FAMA { get; set; }
    }
}