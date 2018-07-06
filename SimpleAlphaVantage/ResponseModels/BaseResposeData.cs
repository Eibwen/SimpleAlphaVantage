using System;
using System.Collections.Generic;

namespace SimpleAlphaVantage.ResponseModels
{
    public abstract class BaseResposeData<T>
    {
        public SparseMetadata Metadata { get; set; }
        public Dictionary<DateTime, T> Data { get; set; }
    }
}