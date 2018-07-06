using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SimpleAlphaVantage.SerializationClasses
{
    [Obsolete("Went with custom JsonConverter for both the root object and Metadata instead", true)]
    public class AlphaVantageContractResolver : DefaultContractResolver
    {
        public AlphaVantageContractResolver()
        {
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);

            List<MemberInfo> serializableMembers = this.GetSerializableMembers(type);
            var multiPrpoertiesToAdd = serializableMembers
                .SelectMany(member => member.GetCustomAttributes<JsonMultiNamePropertyAttribute>()
                    .SelectMany(attribute => attribute.Names
                        .Select(n =>
                            new
                            {
                                Member = member,
                                Name = n
                            })));

            foreach (var toAdd in multiPrpoertiesToAdd)
            {
                var property = CreateProperty(toAdd.Member, memberSerialization);
                property.PropertyName = toAdd.Name;
                properties.Add(property);
            }

            return properties;
        }
    }

    [Obsolete("Went with custom JsonConverter for both the root object and Metadata instead", true)]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
    public class JsonMultiNamePropertyAttribute : Attribute
    {
        public string[] Names { get; }

        public JsonMultiNamePropertyAttribute(params string[] names)
        {
            Names = names;
        }
    }
}