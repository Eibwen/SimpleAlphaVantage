using System;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleAlphaVantage.ResponseModels;

namespace SimpleAlphaVantage.SerializationClasses
{
    public class ParenthesesCurrencyPropertyJsonConverter : JsonConverter<ParenthesesCurrencyBase>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, ParenthesesCurrencyBase value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override ParenthesesCurrencyBase ReadJson(JsonReader reader, Type objectType, ParenthesesCurrencyBase existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            //Alternative would be have a custom attribute on the ones that need it
            //  then need to get all properties of the type, and match them up
            //  using SetValue on the output object
            var jObject = JObject.Load(reader);

            jObject = PreProcessPropertyNames(jObject);

            return (ParenthesesCurrencyBase)jObject.ToObject(objectType);
        }

        private readonly Regex _renameProperty = new Regex(@"^(\da\. .+?) \([A-Z]{3,3}\)$");
        private JObject PreProcessPropertyNames(JObject obj)
        {
            var oldNames = obj.Properties()
                .Select(x => x.Name)
                .Where(x => _renameProperty.IsMatch(x))
                .ToList();
            foreach (var name in oldNames)
            {
                var prop = obj.Property(name);
                prop.Replace(new JProperty(_renameProperty.Match(name).Groups[1].Value, prop.Value));
            }

            return obj;
        }
    }
}