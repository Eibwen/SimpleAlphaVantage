using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SimpleAlphaVantage;
using SimpleAlphaVantage.Enums;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantageTests
{
    [TestFixture]
    public class UriBuildingTests
    {
        [Test]
        public void When_supplied_with_parameters()
        {
            //Arrange
            var mockResponse = new HttpResponseMessage();
            mockResponse.Content = new StringContent("{'two': 'four'}");

            var mockHandler = new MockHttpHandler(mockResponse);
            var httpClient = new HttpClient(mockHandler);

            var client = new GenericApiClient(httpClient);

            //Act
            var response = client.SendGetAsync<TestRequest, JObject>(new Uri("http://test.test.test"), new TestRequest());

            //Assert
            mockHandler.RequestUri.Should().Be("http://test.test.test?fiveAlive=string&one=THREE");
            response.Result.Should().Contain("two", JToken.FromObject("four"));
        }

        [Test]
        public void When_supplied_with_empty_dictionary()
        {
            //Arrange
            var mockResponse = new HttpResponseMessage();
            mockResponse.Content = new StringContent("{'two': 'four'}");

            var mockHandler = new MockHttpHandler(mockResponse);
            var httpClient = new HttpClient(mockHandler);

            var client = new GenericApiClient(httpClient);

            //Act
            var response = client.SendAsync<JObject>(HttpMethod.Get, new Uri("http://test.test.test"), new Dictionary<string,string>());

            //Assert
            mockHandler.RequestUri.Should().Be("http://test.test.test");
            response.Result.Should().Contain("two", JToken.FromObject("four"));
        }

        [Test]
        public void When_appending_further_parameters()
        {
            //Arrange
            var mockResponse = new HttpResponseMessage();
            mockResponse.Content = new StringContent("{'two': 'six'}");

            var mockHandler = new MockHttpHandler(mockResponse);
            var httpClient = new HttpClient(mockHandler);

            var client = new GenericApiClient(httpClient);

            //Act
            var response = client.SendAsync<JObject>(HttpMethod.Get, new Uri("http://test.test.test?already=here&more=there"), new Dictionary<string, string>
            {
                {"and", "plus"},
                {"even", "more"}
            });

            //Assert
            mockHandler.RequestUri.Should().Be("http://test.test.test?already=here&more=there&and=plus&even=more");
            response.Result.Should().Contain("two", JToken.FromObject("six"));
        }

        [Test]
        public void When_string_interpolation_of_enum_should_get_text()
        {
            //Arrange
            var dataType = DataFormat.json;

            //Act
            var urlString = $"https://whatever/query?datatype={dataType}";

            //Assert
            urlString.Should().Be("https://whatever/query?datatype=json");
        }

        private class TestRequest : IRequestParams
        {
            public Dictionary<string, string> ToDictionary()
            {
                return new Dictionary<string, string>
                {
                    {"fiveAlive", "string"},
                    {"one", "THREE"}
                };
            }
        }

        public class MockHttpHandler : HttpMessageHandler
        {
            private readonly HttpResponseMessage _mockResponse;

            public MockHttpHandler(HttpResponseMessage mockResponse)
            {
                _mockResponse = mockResponse;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestUri = request.RequestUri;

                return await Task.FromResult(_mockResponse);
            }

            public Uri RequestUri { get; private set; }
        }
    }
}