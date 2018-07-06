using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleAlphaVantage.ResponseModels;

namespace SimpleAlphaVantage.SerializationClasses
{
    public class MetadataJsonConverter : JsonConverter<SparseMetadata>
    {
        public override void WriteJson(JsonWriter writer, SparseMetadata value, JsonSerializer serializer)
        {
            throw new NotImplementedException("TODO find a way to not include this converter for serialization");
        }

        public override SparseMetadata ReadJson(JsonReader reader, Type objectType, SparseMetadata existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (!hasExistingValue)
            {
                existingValue = new SparseMetadata();
            }

            if (reader.TokenType == JsonToken.StartObject)
            {
                var jObject = JObject.Load(reader);

                foreach (var prop in jObject)
                {
                    var withoutNumber = prop.Key.Substring(3);

                    switch (withoutNumber)
                    {
                        case "Information":
                            existingValue.Information = prop.Value.ToObject<string>();
                            break;
                        case "Symbol":
                            existingValue.Symbol = prop.Value.ToObject<string>();
                            break;
                        case "Last Refreshed":
                            existingValue.LastRefreshed = prop.Value.ToObject<DateTime>(serializer);
                            break;
                        case "Interval":
                            existingValue.Interval = prop.Value.ToObject<string>();
                            break;
                        case "Output Size":
                            existingValue.OutputSize = prop.Value.ToObject<string>();
                            break;
                        case "Time Zone":
                            existingValue.TimeZone = prop.Value.ToObject<string>();
                            break;
                        case "Notes":
                            existingValue.Notes = prop.Value.ToObject<string>();
                            break;
                        default:
                            throw new Exception($"Unknown property in meta data!: '{prop}'");
                    }
                }

                return existingValue;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}