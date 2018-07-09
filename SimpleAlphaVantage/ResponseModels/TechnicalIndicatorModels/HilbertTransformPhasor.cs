using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels.TechnicalIndicatorModels
{
    public class HilbertTransformPhasor
    {
        [JsonProperty("QUADRATURE")]
        public decimal Quadrature { get; set; }
        [JsonProperty("PHASE")]
        public decimal Phase { get; set; }
    }
}