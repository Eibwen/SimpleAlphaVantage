using System.ComponentModel;

namespace SimpleAlphaVantage
{
    public enum OutputType
    {
        [Description("compact")]
        Latest100,
        [Description("full")]
        AllHistory
    }
}