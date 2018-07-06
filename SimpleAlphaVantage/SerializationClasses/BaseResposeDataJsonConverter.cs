﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleAlphaVantage.ResponseModels;

namespace SimpleAlphaVantage.SerializationClasses
{
    public class BaseResposeDataJsonConverter<T> : JsonConverter<BaseResposeData<T>>
    {
        public override void WriteJson(JsonWriter writer, BaseResposeData<T> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override BaseResposeData<T> ReadJson(JsonReader reader, Type objectType, BaseResposeData<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (!hasExistingValue)
            {
                existingValue = (BaseResposeData<T>)Activator.CreateInstance(objectType);
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
                        existingValue.Data = prop.Value.ToObject<Dictionary<DateTime, T>>(serializer);
                    }
                }

                return existingValue;
            }

            //TODO would I require error handling at this level??
            throw new Exception("Expected only 2 top-level properties on a response deserializing to BaseResposeData, but found not 2");
        }
    }
}