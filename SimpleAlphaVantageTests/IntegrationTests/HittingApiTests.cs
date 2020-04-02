using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SimpleAlphaVantage.Api;
using SimpleAlphaVantage.Enums;

namespace SimpleAlphaVantageTests.IntegrationTests
{
    [TestFixture]
    public class HittingApiTests
    {
        [Explicit]
        [TestCase("FZFXX**")]
        public async Task When_(string symbol)
        {
            var apiKey = Environment.GetEnvironmentVariable("AlphaAdvantageApiKey", EnvironmentVariableTarget.User);

            //Arrange
            var api = new StockTimeSeriesData(apiKey);

            //Act
            var data = await api.TimeSeriesIntraday(symbol, IntradayInterval.FiveMinue);

            //Assert

        }
    }
}