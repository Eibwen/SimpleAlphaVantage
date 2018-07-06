using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels
{
    public class TimeSeriesWeeklyAdjusted
    {
        [JsonProperty("Meta Data")]
        public object Metadata { get; set; }

        [JsonProperty("Weekly Adjusted Time Series")]
        public Dictionary<DateTime, AdjustedTimeSeriesData> Data { get; set; }
    }
}