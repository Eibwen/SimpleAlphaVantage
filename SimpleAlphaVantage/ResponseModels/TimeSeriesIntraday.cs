using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using SimpleAlphaVantage.SerializationClasses;

namespace SimpleAlphaVantage.ResponseModels
{
    public class TimeSeriesIntraday
    {
        [JsonProperty("Meta Data")]
        public SparseMetadata Metadata { get; set; }

        [UsedImplicitly]
        [JsonMultiNameProperty("Time Series (1min)")]
        [JsonMultiNameProperty("Time Series (5min)")]
        [JsonMultiNameProperty("Time Series (15min)")]
        [JsonMultiNameProperty("Time Series (30min)")]
        [JsonMultiNameProperty("Time Series (60min)")]
        public Dictionary<DateTime, TimeSeriesData> Data { get; set; }
    }
}