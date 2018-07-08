<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

void Main()
{
	var PATH = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "demoLinks.html");
	var SAVE_PATH = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), @"..\SimpleAlphaVantageTests\ResponseTests\TestData");
	
	var lines = File.ReadAllLines(PATH).Where(x => !string.IsNullOrEmpty(x)).Where(x => !x.StartsWith("#"));
	
	
	var sleepTime = TimeSpan.FromSeconds(5);
	
	var seenFunctions = new List<string>();

	foreach (var line in lines)
	{
		var functionName = Regex.Match(line, @"\?function=(.+?)&").Groups[1].Value;
		
		var id = seenFunctions.Count(x => x == functionName);
		seenFunctions.Add(functionName);
		
		var filepath = Path.Combine(SAVE_PATH, $"{functionName}.{id}.json");

		if (!File.Exists(filepath))
		{
			var result = client.GetAsync(line).Result;
			var body = result.Content.ReadAsStringAsync().Result;

			$"{functionName} -- {result.StatusCode}    ({body.Length})".Dump();

			File.WriteAllText(filepath, body);

			Thread.Sleep(sleepTime);
		}
		else
		{
			$"{functionName} - skipped".Dump();
		}
	}
}
HttpClient client = new HttpClient();
