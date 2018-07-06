using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels
{
    public class TimeSeriesWeekly
    {
        [JsonProperty("Meta Data")]
        public object Metadata { get; set; }

        [JsonProperty("Weekly Time Series")]
        public Dictionary<DateTime, TimeSeriesData> Data { get; set; }
    }
}