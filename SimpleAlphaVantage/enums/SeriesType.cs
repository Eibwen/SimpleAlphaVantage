using System;

namespace SimpleAlphaVantage
{
    public enum SeriesType
    {
        close,
        open,
        high,
        low
    }


    public class DONOTCOMMIT
    {
        public ParamData GetTypeInfo(string function, string parameter)
        {
            switch (parameter)
            {
                case "symbol":
                case "from_currency":
                case "to_currency":
                case "market":
                    return ParamData.CreateRequired("string");
                case "interval":
                    if (function == "TIME_SERIES_INTRADAY")
                        return ParamData.CreateRequired("IntradayInterval", ".GetDescription()");
                    else
                        return ParamData.CreateRequired("TimeInterval", ".GetDescription()");
                case "outputsize":
                    return ParamData.CreateOptional("OutputType", " = OutputType.Latest100", ".GetDescription()");
                case "symbols":
                    return ParamData.CreateRequired("params string[]", toStringLiteral: "string.Join(\",\", symbols)");
                case "time_period":
                    return ParamData.CreateRequired("uint");
                case "series_type":
                    return ParamData.CreateRequired("SeriesType");
                case "fastlimit":
                case "slowlimit":
                    return ParamData.CreateOptional("ufloat", " = 0.01");


                default:
                    throw new Exception($"Unkown parameter: '{function}.{parameter}'");
            }
        }
        public class ParamData
        {
            public static ParamData CreateOptional(string typeName, string defaultValue, string toStringFunc = null)
            {
                return new ParamData(typeName, defaultValue, toStringFunc);
            }

            public static ParamData CreateRequired(string typeName, string toStringFunc = null, string toStringLiteral = null)
            {
                return new ParamData(typeName, null, toStringFunc, toStringLiteral);
            }
            private ParamData(string typeName, string defaultValue = null, string toStringFunc = null, string toStringLiteral = null)
            {
                TypeName = typeName;
                DefaultValue = defaultValue;
                ToStringFunc = toStringFunc;
                ToStringLiteral = toStringLiteral;
            }
            public string TypeName { get; set; }
            public string DefaultValue { get; set; }
            public string ToStringFunc { get; set; }
            public string ToStringLiteral { get; set; }
        }
    }
}