using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleAlphaVantage.ResponseModels;

namespace SimpleAlphaVantage.SerializationClasses
{
    public class MetadataJsonConverter : JsonConverter<SparseMetadata>
    {
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, SparseMetadata value, JsonSerializer serializer)
        {
            throw new NotImplementedException("TODO find a way to not include this converter for serialization");
        }

        private Regex technicalParamPattern = new Regex(@"^\d\.\d:");
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
                    var match = technicalParamPattern.Match(prop.Key);
                    if (match.Success)
                    {
                        AddTechnicalIndicatorParameter(existingValue, prop);
                        continue;
                    }

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

                        case "Digital Currency Code":
                            existingValue.DigitalCurrencyCode = prop.Value.ToObject<string>();
                            break;
                        case "Digital Currency Name":
                            existingValue.DigitalCurrencyName = prop.Value.ToObject<string>();
                            break;
                        case "Market Code":
                            existingValue.MarketCode = prop.Value.ToObject<string>();
                            break;
                        case "Market Name":
                            existingValue.MarketName = prop.Value.ToObject<string>();
                            break;

                        case "Indicator":
                            existingValue.Indicator = prop.Value.ToObject<string>();
                            break;
                        case "Time Period":
                            existingValue.TimePeriod = prop.Value.ToObject<int>();
                            break;
                        case "Series Type":
                            existingValue.SeriesType = prop.Value.ToObject<SeriesType>();
                            break;

                        default:
                            throw new Exception($"Unknown property in meta data!: '{prop}' -- Looking for case \"{withoutNumber}\":");
                    }
                }

                return existingValue;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void AddTechnicalIndicatorParameter(SparseMetadata existingValue, KeyValuePair<string, JToken> prop)
        {
            if (existingValue.TechnicalIndicatorParameters == null)
            {
                existingValue.TechnicalIndicatorParameters = new Dictionary<string, string>();
            }

            existingValue.TechnicalIndicatorParameters.Add(prop.Key, prop.Value.Value<string>());
        }
    }
}