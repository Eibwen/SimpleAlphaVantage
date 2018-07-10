using System.ComponentModel;

namespace SimpleAlphaVantage.Enums
{
    public enum OutputType
    {
        [Description("compact")]
        Latest100,
        [Description("full")]
        AllHistory
    }
}