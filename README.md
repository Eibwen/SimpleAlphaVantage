# Simple Alpha Vantage client

I was not totally happy with the Alpha Vantage clients I found for C#, and thought building my own would be a fun task.

[![NuGet version (Newtonsoft.Json)](https://img.shields.io/nuget/v/SimpleAlphaVantage.svg?style=flat-square)](https://www.nuget.org/packages/SimpleAlphaVantage/)
[![Build Status](https://travis-ci.com/Eibwen/SimpleAlphaVantage.svg?branch=master)](https://travis-ci.com/Eibwen/SimpleAlphaVantage)

### Goals
* Clean and simple interface
* Alpha Vantage's API documentation should nearly be documentation for this library
* Minimal 3rd party dependencies
* Simple to implement and expand on supported endpoints
* Only use the JSON endpoints (unless there are benefits to csv I'm not aware of)
* Typed response objects
* By default, error if new properties are added, or response models change, to try to ensure data quality

#### Warning
* Due to those goals, this library is somewhat meant to be fragile.  If AlphaVantage changes their API, this library **will** likely break.
* But that will nearly guarantee that if this library gives you results, you can trust those results are full and accurate.

### Code Warning
* Due to only using the JSON responses, and Alpha Vantage's output being somewhat difficult to parse, I ended up with a great deal of custom serialization things.  So if you want to learn a lot about Newtonsoft Json's JsonConverter classes, take a look here.  But it would take someone with a lot of Newtonsoft Json experience to modify too much of the internals of this library.

## Versioning
* I plan to use semantic versioning, meaning all 1.x versions should only add new features.  Any breaking of reverse-compatability will cause the major versoin to increase.
* I will aim for only being on 1.x versions unless Alpha Vantage changes their API significantly
  * That said, I'd only expect casing of some of the classes/properties of some of the Technical Indicators might change, which would be a semi-breaking change, but might not bump the major version unless I knew of actual users

## License
I am publishing this under GPL (meaning projects using this must be open-source as well) because there are other libraries out there, and I'd love to see the work of anyone using this.  If you did need a more restricted license feel free to contact me.


## Sample

#### Very basic Linqpad Example:
```
using SimpleAlphaVantage.Api;
using SimpleAlphaVantage.Enums;

async void Main()
{
	var AlphaVantageApiKey = Util.GetPassword("AlphaAdvantage Api Key");
	var client = new StockTimeSeriesData(AlphaVantageApiKey);
	
	var results = await client.TimeSeriesIntraday("MSFT", IntradayInterval.HalfHour);
	
	results.Dump();
}
```
#### Slightly more complex example
```
async void Main()
{
	var AlphaVantageApiKey = Util.GetPassword("AlphaAdvantage Api Key");
	var client = new StockTimeSeriesData(AlphaVantageApiKey);
	
	var results = await client.TimeSeriesDailyAdjusted("MSFT");

	//Get it out of KeyValuePair format and into an anonymous object
	var data = results.Data.Select(x => new
	{
		Date = x.Key,
		AdjustedClose = x.Value.AdjustedClose
	});
	var differences = data.Zip(data.Skip(1), (x, y) => new
	{
		Date = x.Date,
		Growth = x.AdjustedClose - y.AdjustedClose,
		Close = x.AdjustedClose
	});
	
	results.Metadata.Dump();
	
	//Kinda hacky way to get the max valued record
	differences.Where(x => x.Growth == differences.Max(m => m.Growth)).Dump($"Highest growth day in the last 100 days!");
	differences.Dump("All daily deltas");
}
```


## TODO

- [ ] Add TraceWriter of some sort, want to be able to get the url for debugging purposes, and/or the full raw response somehow?  (other than an custom HttpHandler anyway)
  - Could just add that to the output models base class??