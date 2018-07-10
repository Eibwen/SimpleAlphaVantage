using System;
using Newtonsoft.Json;

namespace SimpleAlphaVantage.Utilities.SerializationClasses
{
    public class PercentageJsonConverter : JsonConverter<double>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, double value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override double ReadJson(JsonReader reader, Type objectType, double existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var percentage = reader.Value.ToString();
            return double.Parse(percentage.TrimEnd('%'));
        }
    }
}