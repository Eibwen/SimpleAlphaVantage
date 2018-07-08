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
            var enumNameTitleCase = EnumNamePascalCase(function);

            //Act & Assert
            GetAllMethods.Value.Any(x => x.Name == function.ToString() || x.Name == enumNameTitleCase).Should().BeTrue();
        }

        public static string EnumNamePascalCase(ApiFunction function)
        {
            var textInfo = CultureInfo.InvariantCulture.TextInfo;

            var enumNameTitleCase = textInfo.ToTitleCase(function.ToString().ToLowerInvariant()).Replace("_", "");
            return enumNameTitleCase;
        }

        public static Lazy<IEnumerable<MethodInfo>> GetAllMethods => new Lazy<IEnumerable<MethodInfo>>(() =>
        {
            var classesToLookIn = new[]
            {
                typeof(StockTimeSeriesData),
                typeof(DigitalCryptoCurrencies),
                typeof(ForeignExchange),
                typeof(TechnicalIndicators),
                typeof(SectorPerformances)
            };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            return classesToLookIn.SelectMany(x => x.GetMethods(bindingFlags));
        });
    }
}