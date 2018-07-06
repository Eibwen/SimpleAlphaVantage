using System;
using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels
{
    public class BatchQuote
    {
        [JsonProperty("1. symbol")]
        public string Symbol { get; set; }
        [JsonProperty("2. price")]
        public decimal Price { get; set; }
        [JsonProperty("3. volume")]
        public long Volume { get; set; }
        [JsonProperty("4. timestamp")]
        public DateTime Timestamp { get; set; }
    }
}