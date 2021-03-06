﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleAlphaVantage.Exceptions;
using SimpleAlphaVantage.ResponseModels;

namespace SimpleAlphaVantage.Utilities.SerializationClasses
{
    public class TechnicalIndicatorSingleValueJsonConverter : JsonConverter<BaseResponseData<decimal>>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, BaseResponseData<decimal> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override BaseResponseData<decimal> ReadJson(JsonReader reader, Type objectType, BaseResponseData<decimal> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (!hasExistingValue)
            {
                existingValue = (BaseResponseData<decimal>)Activator.CreateInstance(objectType);
            }

            var thisObject = JObject.Load(reader);

            if (thisObject.Count == 2)
            {
                //should be able to assume one is "Meta Data" and the other is the data array
                foreach (var prop in thisObject)
                {
                    if (prop.Key == "Meta Data")
                    {
                        existingValue.Metadata = prop.Value.ToObject<SparseMetadata>(serializer);
                    }
                    else
                    {
                        //var tempData = prop.Value.ToObject<Dictionary<DateTime, JObject>>(serializer);
                        //existingValue.Data = tempData.ToDictionary(x => x.Key,
                        //	x => x.Value.Cast<KeyValuePair<string, JToken>>()
                        //		.Single().Value.Value<decimal>());
                        var tempData = prop.Value.ToObject<Dictionary<DateTime, Dictionary<string, decimal>>>(serializer);
                        existingValue.Data = tempData.ToDictionary(x => x.Key,
                            x => x.Value.Single().Value);
                    }
                }

                return existingValue;
            }

            if (thisObject.Count == 1 && thisObject.Properties().First().Name == "Information")
            {
                throw new AlphaVantageException("Error from AlphaVantage: " + thisObject.Properties().First().Value);
            }

            //TODO would I require error handling at this level??
            throw new Exception("Expected only 2 top-level properties on a response deserializing to BaseResponseData, but found not 2");
        }
    }
}