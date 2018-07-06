using System;

namespace SimpleAlphaVantage
{
    public enum DataFormat
    {
        json,
        [Obsolete("Would need to rebuild the clients to support this, expect both responses are cached so not much benefit other than minor savings on the wire", true)]
        csv
    }
}