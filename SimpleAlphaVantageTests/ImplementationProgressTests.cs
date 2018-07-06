using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using SimpleAlphaVantage;
using SimpleAlphaVantage.Api;

namespace SimpleAlphaVantageTests
{
    [TestFixture]
    public class ImplementationProgressTests
    {
        [Theory]
        public void All_enum_values_should_be_implemented(ApiFunction function)
        {
            //Arrange
            var enumName = function.ToString();
            var textInfo = new CultureInfo("en-US", false).TextInfo;
            var enumNameTitleCase = textInfo.ToTitleCase(enumName.ToLowerInvariant()).Replace("_", "");

            //Act & Assert
            GetAllMethods.Value.Any(x => x.Name == enumName || x.Name == enumNameTitleCase).Should().BeTrue();
        }

        public static Lazy<IEnumerable<MethodInfo>> GetAllMethods => new Lazy<IEnumerable<MethodInfo>>(() =>
        {
            var classesToLookIn = new[]
            {
                typeof(StockTimeSeriesData)
            };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            return classesToLookIn.SelectMany(x => x.GetMethods(bindingFlags));
        });
    }
}