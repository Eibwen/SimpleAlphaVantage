using System.IO;
using System.Net.Http;
using NUnit.Framework;
using SimpleAlphaVantage;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantageTests.ResponseTests
{
    [TestFixture]
    public class DeserializeTestDataTests
    {
        public string ReadFile(ApiFunction function)
        {
            return File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, $@"ResponseTests\TestData\{function}.json"));
        }

        [Test]
        public void When_manually_built_test()
        {
            //Arrange
            var response = ReadFile(ApiFunction.SECTOR);
            var client = new GenericApiClient();

            //Act
            var result = client.DeserializeWithSettings<Sector>(response);

            //Assert

            //TODO add some assertions here
        }
    }
}