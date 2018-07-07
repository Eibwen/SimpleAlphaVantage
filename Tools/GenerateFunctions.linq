<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	var PATH = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "documentationExportProcessed.html");
	
	var lines = File.ReadAllLines(PATH).Where(x => !string.IsNullOrEmpty(x))
					.Where(x => !x.StartsWith("# "));
	
	List<Parameter> currentList = null;
	var parameters = new Dictionary<string, List<Parameter>>();
	foreach (var l in lines)
	{
		if (l.StartsWith("@###"))
		{
			currentList = new List<Parameter>();
			parameters.Add(Regex.Match(l, "^@###(.+?)( <|$)").Groups[1].Value, currentList);
		}
		else
		{
			var name = l.Replace("Required:", "").Replace("Optional:", "").Trim();
			var isRequired = l.StartsWith("Required");

			currentList.Add(new Parameter { Name = name, IsRequired = isRequired });
		}
	}
	
	//parameters.Dump();
	foreach (var kvp in parameters)
	{
		GenerateFunction(kvp).Dump();
		"".Dump();
	}
}
public class Parameter
{
	public string Name { get; set; }
	public bool IsRequired { get; set; }
}


TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
public string GenerateFunction(KeyValuePair<string, List<Parameter>> kvp)
{
	var rawName = kvp.Key.Replace('_', ' ').ToLower();
	var functionName = textInfo.ToTitleCase(rawName).Replace(" ", "");

	var defaultParams = new[] { "function", "apikey", "datatype" };
	
	var paramsToAdd = kvp.Value.Where(x => !defaultParams.Contains(x.Name));
	
	var functionParameters = new List<string>();
	var parameterCollectionInitializer = new List<string>();
	
	
	foreach (var param in paramsToAdd)
	{
		var name = param.Name.Replace('_', ' ').ToLower();
		name = textInfo.ToTitleCase(name).Replace(" ", "");
		var paramNameCSharp = Char.ToLowerInvariant(name[0]) + name.Substring(1);
		
		var paramType = GetTypeInfo(kvp.Key, param.Name);

		functionParameters.Add($"{paramType.TypeName} {paramNameCSharp}{paramType.DefaultValue}");
		
		var toString = (paramType.ToStringLiteral == null)
				? paramNameCSharp + paramType.ToStringFunc
				: paramType.ToStringLiteral;
		parameterCollectionInitializer.Add($@"{{""{param.Name}"", {toString}}}");
	}
	
	
	var isTechnicalIndicator = kvp.Key.Length <= 12 && kvp.Key != "SECTOR";
	
	var returnObject = isTechnicalIndicator
				? "TechnicalIndicator"
				: functionName;
	if (isTechnicalIndicator)
	{
		functionName = kvp.Key;
	}

	return $@"        public async Task<{returnObject}> {functionName}({string.Join(", ", functionParameters)})
        {{
            return await ApiClient.SendGetAsync<{returnObject}>(BuildUri(ApiFunction.{kvp.Key}), new Dictionary<string, string>
            {{
                {string.Join(",\r\n                ", parameterCollectionInitializer)}
            }});
        }}";
}

public ParamData GetTypeInfo(string function, string parameter)
{
	switch (parameter)
	{
		case "symbol":
		case "from_currency":
		case "to_currency":
		case "market":
			return ParamData.CreateRequired("string");
		case "interval":
			if (function == "TIME_SERIES_INTRADAY")
				return ParamData.CreateRequired("IntradayInterval", ".GetDescription()");
			else
				return ParamData.CreateRequired("TimeInterval", ".GetDescription()");
		case "outputsize":
			return ParamData.CreateOptional("OutputType", " = OutputType.Latest100", ".GetDescription()");
		case "symbols":
			return ParamData.CreateRequired("params string[]", toStringLiteral: "string.Join(\",\", symbols)");
		case "time_period":
			return ParamData.CreateRequired("uint");
		case "series_type":
			return ParamData.CreateRequired("SeriesType");
		case "fastlimit":
		case "slowlimit":
		case "acceleration":
			return ParamData.CreateOptional("float", " = 0.01f", ".ToString(CultureInfo.InvariantCulture)");
		case "fastperiod":
			return (function == "ADOSC")
				? ParamData.CreateOptional("uint", " = 3")
				: ParamData.CreateOptional("uint", " = 12");
		case "slowperiod":
			return ParamData.CreateOptional("uint", (function == "ADOSC") ? " = 10" : " = 26");
		case "signalperiod":
			return ParamData.CreateOptional("uint", " = 9");
		case "fastmatype":
		case "slowmatype":
		case "signalmatype":
		case "slowkmatype":
		case "slowdmatype":
		case "fastdmatype":
		case "matype":
			return ParamData.CreateOptional("MovingAverageType", " = MovingAverageType.Simple", toStringLiteral: $"((int){parameter}).ToString()");
		case "fastkperiod":
			return ParamData.CreateOptional("uint", " = 5");
		case "slowkperiod":
		case "slowdperiod":
		case "fastdperiod":
			return ParamData.CreateOptional("uint", " = 3");
		case "timeperiod1":
			return ParamData.CreateOptional("uint", " = 7");
		case "timeperiod2":
			return ParamData.CreateOptional("uint", " = 14");
		case "timeperiod3":
			return ParamData.CreateOptional("uint", " = 28");
		case "nbdevup":
		case "nbdevdn":
			return ParamData.CreateOptional("uint", " = 2");
		case "maximum":
			return ParamData.CreateOptional("float", " = 0.20f", ".ToString(CultureInfo.InvariantCulture)");


		default:
			throw new Exception($"Unknown parameter: '{function}.{parameter}'");
	}
}
public class ParamData
{
	public static ParamData CreateOptional(string typeName, string defaultValue, string toStringFunc = null, string toStringLiteral = null)
	{
		return new ParamData(typeName, defaultValue, toStringFunc, toStringLiteral);
	}

	public static ParamData CreateRequired(string typeName, string toStringFunc = null, string toStringLiteral = null)
	{
		return new ParamData(typeName, null, toStringFunc, toStringLiteral);
	}
	private ParamData(string typeName, string defaultValue = null, string toStringFunc = null, string toStringLiteral = null)
	{
		TypeName = typeName;
		DefaultValue = defaultValue;
		ToStringFunc = toStringFunc;
		ToStringLiteral = toStringLiteral;
		
		if (ToStringFunc == null && TypeName != "string")
		{
			ToStringFunc = ".ToString()";
		}
	}
	public string TypeName { get; set; }
	public string DefaultValue { get; set; }
	public string ToStringFunc { get; set; }
	public string ToStringLiteral { get; set; }
}