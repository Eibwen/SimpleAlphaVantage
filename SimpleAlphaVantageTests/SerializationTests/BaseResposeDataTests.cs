using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantageTests.SerializationTests
{
    [TestFixture]
    public class BaseResposeDataTests
    {
        [Test]
        public void When_deserializing_response_body()
        {
            var responseJson = @"{""Meta Data"":{""1. Information"":""Daily Prices (open, high, low, close) and Volumes"",""2. Symbol"":""MSFT"",""3. Last Refreshed"":""2018-07-06"",""4. Output Size"":""Compact"",""5. Time Zone"":""US/Eastern""},""Time Series (Daily)"":{""2018-07-06"":{""1. open"":""99.8850"",""2. high"":""101.4300"",""3. low"":""99.6700"",""4. close"":""101.1600"",""5. volume"":""18238379""},""2018-07-05"":{""1. open"":""99.5000"",""2. high"":""99.9200"",""3. low"":""99.0299"",""4. close"":""99.7600"",""5. volume"":""18583217""}}}";
            var client = new GenericApiClient();

            //Act
            var materialized = client.DeserializeWithSettings<TimeSeriesDaily>(responseJson);

            //Assert
            materialized.Data.Should().HaveCount(2);
            materialized.Data.First().Value.Close.Should().Be(101.1600m);

            materialized.Metadata.Information.Should().Be("Daily Prices (open, high, low, close) and Volumes");
            materialized.Metadata.Symbol.Should().Be("MSFT");
            materialized.Metadata.LastRefreshed.Should().Be(new DateTime(2018, 7, 6));
            materialized.Metadata.Interval.Should().BeNull();
            materialized.Metadata.OutputSize.Should().Be("Compact");
            materialized.Metadata.TimeZone.Should().Be("US/Eastern");
            materialized.Metadata.Notes.Should().BeNull();
        }
    }
}