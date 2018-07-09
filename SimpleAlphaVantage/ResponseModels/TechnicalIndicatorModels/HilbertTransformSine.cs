using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels.TechnicalIndicatorModels
{
    public class HilbertTransformSine
    {
        [JsonProperty("SINE")]
        public decimal Sine { get; set; }
        [JsonProperty("LEAD SINE")]
        public decimal LeadSine { get; set; }
    }
}