using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SimpleAlphaVantage.ResponseModels;

namespace SimpleAlphaVantage.SerializationClasses
{
    public class DataPropertyJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return SupportedTypes.Contains(objectType);
        }

        private static readonly HashSet<Type> SupportedTypes = new HashSet<Type>
        {
            typeof(TimeSeriesIntraday)
        };
    }
}