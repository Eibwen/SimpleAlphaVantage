using System;
using System.Collections.Generic;

namespace SimpleAlphaVantage.ResponseModels
{
    /// <summary>
    /// Many of these properties may be null, depending on what endpoint the metadata came from
    /// </summary>
    public class SparseMetadata
    {
        public string Information { get; set; }
        public string Symbol { get; set; }
        /// <summary>
        /// Can't be <c>DateTime?</c> because sometimes the value is <c>2018-07-06 (end of day)</c>
        /// Specifically ONLY for <c>DIGITAL_CURRENCY_*</c>...
        /// </summary>
        public string LastRefreshed { get; set; }
        public string Interval { get; set; }
        public string OutputSize { get; set; }
        public string Notes { get; set; }
        public string TimeZone { get; set; }

        public string DigitalCurrencyCode { get; set; }
        public string DigitalCurrencyName { get; set; }
        public string MarketCode { get; set; }
        public string MarketName { get; set; }

        public string Indicator { get; set; }
        public int TimePeriod { get; set; }
        public SeriesType SeriesType { get; set; }
        public float Volumefactor { get; set; }

        public Dictionary<string, string> TechnicalIndicatorParameters { get; set; }
    }
}