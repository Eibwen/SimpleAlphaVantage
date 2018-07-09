using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels.TechnicalIndicatorModels
{
    public class Aroon
    {
        [JsonProperty("Aroon Up")]
        public decimal AroonUp { get; set; }
        [JsonProperty("Aroon Down")]
        public decimal AroonDown { get; set; }
    }
}