using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SimpleAlphaVantage;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantageTests.ResponseTests
{
    [TestFixture]
    public class DeserializeTestDataTests
    {
        public static string ReadFile(ApiFunction function, int id = 0)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, $@"ResponseTests\TestData\{function}.{id}.json");
            if (File.Exists(path))
            {
                Console.WriteLine($"Reading file: {Path.GetFileName(path)}");

                return File.ReadAllText(path);
            }

            return null;
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

        [Test]
        public void When_manually_built_test_of_type()
        {
            //Arrange
            var response = ReadFile(ApiFunction.SECTOR);
            var client = new GenericApiClient();

            //Act
            var result = client.DeserializeWithSettings(response, typeof(Sector));

            //Assert

            //TODO add some assertions here
        }

        /// <summary>
        /// Not sure if this test is a good idea or not...
        ///
        /// Very complicated to build up everything dynamically with how I'm doing everything...
        /// </summary>
        //[TestCaseSource(nameof(GetDeserializationData))]
        [Theory]
        public void When_deserializing_all_sample_files(ApiFunction function)
        {
            //Arrange
            var methodInfos = ImplementationProgressTests.GetAllMethods.Value;
            var methodForThisFunction = methodInfos.Single(x => x.Name == function.ToString() || x.Name == ImplementationProgressTests.EnumNamePascalCase(function));

            var returnTypeTask = methodForThisFunction.ReturnType;
            var returnType = returnTypeTask.GenericTypeArguments[0];

            var client = new GenericApiClient();

            var id = 0;
            for (; id < 5; id++)
            {
                var sampleFileContent = ReadFile(function, id);
                if (sampleFileContent == null)
                {
                    break;
                }

                //Act
                var result = client.DeserializeWithSettings(sampleFileContent, returnType);

                //Assert
                // count all the non-default property values, if deserialization failed, the values should be defaults
                var nonDefaultProperties = CountNonDefaultProperties(result);
                Console.WriteLine("Non-default property count: " + nonDefaultProperties);

                nonDefaultProperties.Should().BeGreaterOrEqualTo(GetMinimumExpectedProperties(function));
            }

            if (id == 0)
            {
                Assert.Warn("NO TEST DATA WAS FOUND");
            }
        }

        private int GetMinimumExpectedProperties(ApiFunction function)
        {
            switch (function)
            {
                case ApiFunction.CURRENCY_EXCHANGE_RATE:
                    return 5;
                case ApiFunction.SECTOR:
                    return 100;

                default:
                    return 200;
            }
        }

        public int CountNonDefaultProperties(object obj)
        {
            // Let JsonConvert do the work of stripping out default values
            var serialized = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

            // Recurse into the json structure, which is much simpler than C# Object structure
            var jObj = JObject.Parse(serialized);

            return CountJTokenProperties(jObj);
        }

        private static int CountJTokenProperties(JToken token)
        {
            var sum = 0;

            if (token.Type == JTokenType.Object)
            {
                foreach (var child in token.Value<JObject>())
                {
                    sum += CountJTokenProperties(child.Value);
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (var child in token.Value<JArray>())
                {
                    sum += CountJTokenProperties(child);
                }
            }
            else
            {
                sum += 1;
            }

            return sum;
        }
    }
}