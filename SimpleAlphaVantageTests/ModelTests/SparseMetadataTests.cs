using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SimpleAlphaVantage.ResponseModels;

namespace SimpleAlphaVantageTests.ModelTests
{
    [TestFixture]
    public class SparseMetadataTests
    {
        [Test]
        public void All_properties_on_sparse_metadata_should_be_nullable()
        {
            //Arrange
            //TODO could add binding flags but not really necessary either for a POCO DTO
            var properties = typeof(SparseMetadata).GetProperties();
            var fields = typeof(SparseMetadata).GetFields();

            Func<Type, bool> canBeNull = type => !type.IsValueType || (Nullable.GetUnderlyingType(type) != null);

            //Act
            var types = properties.Select(x => x.PropertyType)
                .Concat(fields.Select(x => x.FieldType));

            //Assert
            types.Select(canBeNull).Should().OnlyContain(x => x);
        }
    }
}