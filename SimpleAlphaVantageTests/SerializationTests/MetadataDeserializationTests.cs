using System;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantageTests.SerializationTests
{
    [TestFixture]
    public class MetadataDeserializationTests
    {
        [Test]
        public void When_deserializing_metadata()
        {
            //Arrange
            var responseJson = @"{""Meta Data"":{""1. Information"":""Intraday (15min) prices and volumes"",""2. Symbol"":""MSFT"",""3. Last Refreshed"":""2018-07-06 16:00:00"",""4. Interval"":""15min"",""5. Output Size"":""Compact"",""6. Time Zone"":""US/Eastern""},""Time Series (15min)"":{""2018-07-06 16:00:00"":{""1. open"":""100.9850"",""2. high"":""101.2500"",""3. low"":""100.7100"",""4. close"":""101.1600"",""5. volume"":""4248932""},""2018-07-06 15:45:00"":{""1. open"":""101.4050"",""2. high"":""101.4300"",""3. low"":""101.0400"",""4. close"":""101.0400"",""5. volume"":""570066""},""2018-07-06 15:30:00"":{""1. open"":""101.2200"",""2. high"":""101.4200"",""3. low"":""101.2000"",""4. close"":""101.4000"",""5. volume"":""441079""}}}";
            var client = new TestGenericApiClient();

            //Act
            var materialized = client.DeserializeWithSettings<TimeSeriesIntraday>(responseJson);

            //Assert
            materialized.Data.Should().HaveCount(3);

            materialized.Metadata.Information.Should().Be("Intraday (15min) prices and volumes");
            materialized.Metadata.Symbol.Should().Be("MSFT");
            materialized.Metadata.LastRefreshed.Should().Be(new DateTime(2018, 7, 6, 16, 0, 0));
            materialized.Metadata.Interval.Should().Be("15min");
            materialized.Metadata.OutputSize.Should().Be("Compact");
            materialized.Metadata.TimeZone.Should().Be("US/Eastern");
            materialized.Metadata.Notes.Should().BeNull();
        }

        private class TestGenericApiClient : GenericApiClient
        {
            //TODO why not have this sort of method in the actual class???
            public T DeserializeWithSettings<T>(string json)
            {
                return JsonConvert.DeserializeObject<T>(json, JsonSettings);
            }
        }
    }
}