using FluentAssertions;
using NUnit.Framework;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantageTests.SerializationTests
{
    [TestFixture]
    public class CurrencyConversionDeserializationTests
    {
        [Test]
        public void When_deserializing_multicurrency_responses_should_get_all_values()
        {
            //Arrange
            var responseJson = @"{""Meta Data"":{""1. Information"":""Intraday Prices and Volumes for Digital Currency"",""2. Digital Currency Code"":""BTC"",""3. Digital Currency Name"":""Bitcoin"",""4. Market Code"":""EUR"",""5. Market Name"":""Euro"",""6. Interval"":""5min"",""7. Last Refreshed"":""2018-07-06 23:15:00"",""8. Time Zone"":""UTC""},""Time Series (Digital Currency Intraday)"":{""2018-07-06 23:15:00"":{""1a. price (EUR)"":""5614.25205722"",""1b. price (USD)"":""6598.71423375"",""2. volume"":""12054.88574590"",""3. market cap (USD)"":""79546746.15772399""},""2018-07-06 23:10:00"":{""1a. price (EUR)"":""5607.13276119"",""1b. price (USD)"":""6590.34656526"",""2. volume"":""12039.62198342"",""3. market cap (USD)"":""79345281.38542400""},""2018-07-06 23:05:00"":{""1a. price (EUR)"":""5609.58382787"",""1b. price (USD)"":""6593.22742783"",""2. volume"":""12045.28001062"",""3. market cap (USD)"":""79417270.54190400""}}}";
            var client = new GenericApiClient();

            //Act
            var materialized = client.DeserializeWithSettings<DigitalCurrencyIntraday>(responseJson);

            //Assert
            materialized.Data.Should().HaveCount(3);

            materialized.Data.Values.Should().BeEquivalentTo(
                new DigitalCurrencySpotData
                {
                    Price = 5614.25205722m,
                    PriceUSD = 6598.71423375m,
                    Volume = 12054.88574590m,
                    MarketCap = 79546746.15772399m
                },
                new DigitalCurrencySpotData
                {
                    Price = 5607.13276119M,
                    PriceUSD = 6590.34656526M,
                    Volume = 12039.62198342M,
                    MarketCap = 79345281.38542400M
                },
                new DigitalCurrencySpotData
                {
                    Price = 5609.58382787M,
                    PriceUSD = 6593.22742783M,
                    Volume = 12045.28001062M,
                    MarketCap = 79417270.54190400M
                });
        }
    }
}