using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels
{
    public class BatchStockQuotes
    {
        [JsonProperty("Meta Data")]
        public SparseMetadata Metadata { get; set; }
        [JsonProperty("Stock Quotes")]
        public List<BatchQuote> StockQuotes { get; set; }
    }
}