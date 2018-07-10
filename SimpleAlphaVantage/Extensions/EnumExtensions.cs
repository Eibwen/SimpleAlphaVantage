using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SimpleAlphaVantage.Extensions
{
    internal static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes = fi.GetCustomAttributes<DescriptionAttribute>(false).ToArray();

            return attributes.Any()
                ? attributes.First().Description
                : value.ToString();
        }
    }
}