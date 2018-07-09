# Simple Alpha Vantage client

I was not totally happy with the Alpha Vantage clients I found for C#, and thought building my own would be a fun task.

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

