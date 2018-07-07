using System;

namespace SimpleAlphaVantage.ResponseModels
{
    /// <summary>
    /// Many of these properties may be null, depending on what endpoint the metadata came from
    /// </summary>
    public class SparseMetadata
    {
        public string Information { get; set; }
        public string Symbol { get; set; }
        public DateTime? LastRefreshed { get; set; }
        public string Interval { get; set; }
        public string OutputSize { get; set; }
        public string Notes { get; set; }
        public string TimeZone { get; set; }

        public string DigitalCurrencyCode { get; set; }
        public string DigitalCurrencyName { get; set; }
        public string MarketCode { get; set; }
        public string MarketName { get; set; }
    }
}