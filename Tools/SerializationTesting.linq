<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

void Main()
{
	var json = @"{""Meta Data"":{""1: Symbol"":""MSFT"",""2: Indicator"":""Exponential Moving Average (EMA)"",""3: Last Refreshed"":""2018-07-06 16:00:00"",""4: Interval"":""15min"",""5: Time Period"":10,""6: Series Type"":""close"",""7: Time Zone"":""US/Eastern""},""Technical Analysis: EMA"":{""2018-07-06 16:00"":{""EMA"":""101.1270""},""2018-07-06 15:45"":{""EMA"":""101.1197""},""2018-07-06 15:30"":{""EMA"":""101.1374""}}}";


	//MethodOne(json);
	MethodTwo(json);
}




/*
It seems like this needs JUST as many pieces to work as MethodOne...

So going with MethodOne because its a bit simpler...
TODO refactor MethodOne so that as much code duplication is reduced as possible?
*/
public void MethodTwo(string json)
{
	var JsonSettings = new JsonSerializerSettings
	{
		MissingMemberHandling = MissingMemberHandling.Error
	};
	JsonSettings.Converters.Add(new MetadataJsonConverter());
	JsonSettings.Converters.Add(new TechnicalIndicatorJsonConverter());
	
	

	JsonConvert.DeserializeObject<TechnicalIndicator>(json, JsonSettings).Dump();
}
public class TechnicalIndicator
{
	public SparseMetadata Metadata { get; set; }
	[JsonProperty(ItemConverterType = typeof(TechnicalIndicatorItemJsonConverter))]
	public Dictionary<DateTime, decimal> Data { get; set; }
}
public class TechnicalIndicatorItemJsonConverter : JsonConverter<decimal>
{
	public override bool CanWrite => false;
	public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
	{
		throw new NotImplementedException();
	}

	public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		var thisObject = JObject.Load(reader);
		
		return thisObject.Values().Single().Value<decimal>();
	}
}
public class TechnicalIndicatorJsonConverter : JsonConverter<TechnicalIndicator>
{
	public override bool CanWrite => false;
	public override void WriteJson(JsonWriter writer, TechnicalIndicator value, JsonSerializer serializer)
	{
		throw new NotImplementedException();
	}

	public override TechnicalIndicator ReadJson(JsonReader reader, Type objectType, TechnicalIndicator existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		var output = new TechnicalIndicator();
		// Read property name:
		reader.Read();
		if ((string)reader.Value == "Meta Data")
		{
			// Read StartObject
			reader.Read();
			// Get Metadata object
			output.Metadata = JObject.Load(reader).ToObject<SparseMetadata>(serializer);
			// Read EndObject
			reader.Read();
		}

		reader.TokenType.Dump();
		if ((string)reader.Value != "Meta Data")
		{
			// Read StartObject
			reader.Read();
			// Get Data Dictionary
			//JObject.Load(reader).ToObject<Dictionary<DateTime, decimal>>(serializer);
			var converter = new TechnicalIndicatorItemJsonConverter();
			output.Data = converter.ReadJson(reader, 
			
			// Read EndObject
			reader.Read();
		}

		return null;
	}
}






/*
Downside of this method is the amount of code duplication between TechnicalIndicatorSingleValueJsonConverter and BaseResposeDataJsonConverter
Only at the goal of keeping `TechnicalIndicator : BaseResposeData<decimal>` empty???

Not sure whats happening in the Deserialize to Diciotnary, then Single... but imagine thats not ideal performance overall
*/
public void MethodOne(string json)
{
	var JsonSettings = new JsonSerializerSettings
	{
		MissingMemberHandling = MissingMemberHandling.Error
	};
	JsonSettings.Converters.Add(new MetadataJsonConverter());
	//	//TODO do some sort of scan to find all of these:
	//	JsonSettings.Converters.Add(new BaseResposeDataJsonConverter<TimeSeriesData>());
	//	JsonSettings.Converters.Add(new BaseResposeDataJsonConverter<AdjustedTimeSeriesData>());
	//	JsonSettings.Converters.Add(new BaseResposeDataJsonConverter<DigitalCurrencySpotData>());
	//	JsonSettings.Converters.Add(new BaseResposeDataJsonConverter<DigitalCurrencyFullData>());
	JsonSettings.Converters.Add(new TechnicalIndicatorSingleValueJsonConverter());




	JsonConvert.DeserializeObject<TechnicalIndicator1>(json, JsonSettings).Dump();
}



public class TechnicalIndicator1 : BaseResposeData<decimal>
{
}
public abstract class BaseResposeData<T>
{
	public SparseMetadata Metadata { get; set; }
	public Dictionary<DateTime, T> Data { get; set; }
}
public class SparseMetadata
{
	public string Information { get; set; }
	public string Symbol { get; set; }
	public DateTime? LastRefreshed { get; set; }
	public string Interval { get; set; }
	public string OutputSize { get; set; }
	public string Notes { get; set; }
	public string TimeZone { get; set; }

	public string DigitalCurrencyCode { get; set; }
	public string DigitalCurrencyName { get; set; }
	public string MarketCode { get; set; }
	public string MarketName { get; set; }
}



public class TechnicalIndicatorSingleValueJsonConverter : JsonConverter<BaseResposeData<decimal>>
{
	public override bool CanWrite => false;

	public override void WriteJson(JsonWriter writer, BaseResposeData<decimal> value, JsonSerializer serializer)
	{
		throw new NotImplementedException();
	}

	public override BaseResposeData<decimal> ReadJson(JsonReader reader, Type objectType, BaseResposeData<decimal> existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		if (!hasExistingValue)
		{
			existingValue = (BaseResposeData<decimal>)Activator.CreateInstance(objectType);
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

		//TODO would I require error handling at this level??
		throw new Exception("Expected only 2 top-level properties on a response deserializing to BaseResposeData, but found not 2");
	}
}










public class MetadataJsonConverter : JsonConverter<SparseMetadata>
{
	public override bool CanWrite => false;
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
					default:
						//throw new Exception($"Unknown property in meta data!: '{prop}'");
						break;
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