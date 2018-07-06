using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;
using SimpleAlphaVantage.Api;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantageTests
{
    [TestFixture]
    public class FunctionImplementationAccuracyTests
    {
        [Test]
        [Ignore("Need to build up parameters")]
        public void When_methods_call_query_api_function_should_match_method_name()
        {
            //Arrange
            var mockResponse = new HttpResponseMessage();
            mockResponse.StatusCode = HttpStatusCode.NotFound;

            var mockHandler = new UriBuildingTests.MockHttpHandler(mockResponse);
            var httpClient = new HttpClient(mockHandler);

            var client = new GenericApiClient(httpClient);

            var stockTimeSeriesData = new StockTimeSeriesData("apifake", client);

            //Act
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            var methodsToCheck = stockTimeSeriesData.GetType().GetMethods(bindingFlags);

            //TODO would be nice to use a TestCaseSource or Theory, but ehhhh

            Assert.Multiple(() =>
            {
                //Assert
                foreach (var method in methodsToCheck)
                {
                    //TODO bulid or find a library to invoke based on parameter names...
                    //method.Invoke(stockTimeSeriesData, )

                    var foundFunction = Regex.Match(mockHandler.RequestUri.ToString(), "function=(.+?)(&|$)");
                    var textInfo = new CultureInfo("en-US", false).TextInfo;
                    var enumNameTitleCase = textInfo.ToTitleCase(foundFunction.Groups[1].Value.ToLowerInvariant()).Replace("_", "");
                    Assert.That(method.Name, Is.EqualTo(enumNameTitleCase));
                }
            });
        }
    }
}