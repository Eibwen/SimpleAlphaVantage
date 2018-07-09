using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels.TechnicalIndicatorModels
{
    public class Macd
    {
        [JsonProperty("MACD")]
        public decimal MACD { get; set; }
        [JsonProperty("MACD_Signal")]
        public decimal MACDSignal { get; set; }
        [JsonProperty("MACD_Hist")]
        public decimal MACDHist { get; set; }
    }
}