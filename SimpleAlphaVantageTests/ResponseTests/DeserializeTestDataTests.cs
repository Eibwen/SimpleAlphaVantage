using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                //TODO add some assertions here, count all the non-default property values somehow?
            }

            if (id == 0)
            {
                Assert.Warn("NO TEST DATA WAS FOUND");
            }
        }

        //public static IEnumerable<TestCaseData> GetDeserializationData()
        //{

        //    foreach (ApiFunction function in Enum.GetValues(typeof(ApiFunction)))
        //    {

        //        //NOTE: when inside of this, CurrentContext.TestDirectory, the current context is still being built up!  So that directory is of the nunit.dll
        //        //  I COULD use WorkingDirectory... but that doesn't seem as valid, could break if wanted to run tests in parallel
        //        //var fileContents = ReadFile(function, id);

        //        yield return new TestCaseData(function).SetName($"{function} samples");
        //    }
        //}
    }
}