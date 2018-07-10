using System.ComponentModel;

namespace SimpleAlphaVantage.Enums
{
    public enum IntradayInterval
    {
        [Description("1min")]
        OneMinute,
        [Description("5min")]
        FiveMinue,
        [Description("15min")]
        FifteenMinute,
        [Description("30min")]
        HalfHour,
        [Description("60min")]
        OneHour
    }

    public enum TimeInterval
    {
        [Description("1min")]
        OneMinute,
        [Description("5min")]
        FiveMinue,
        [Description("15min")]
        FifteenMinute,
        [Description("30min")]
        HalfHour,
        [Description("60min")]
        OneHour,
        [Description("daily")]
        Daily,
        [Description("weekly")]
        Weekly,
        [Description("monthly")]
        Monthly
    }
}