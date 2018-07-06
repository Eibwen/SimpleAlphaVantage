using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
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

        public class TestRequest : IRequestParams
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

                return await Task.FromResult<HttpResponseMessage>(_mockResponse);
            }

            public Uri RequestUri { get; set; }
        }
    }
}