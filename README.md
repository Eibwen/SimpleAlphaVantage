# Simple Alpha Vantage client

I was not totally happy with the Alpha Vantage clients I found for C#, and thought building my own would be a fun task.

### Goals
* Clean and simple interface
* Minimal 3rd party dependencies
* Simple to implement and expand on supported endpoints
* Typed response objects
* By default, error if new properties are added, or response models change, to try to ensure data quality

#### Warning
* Due to those goals, this library is somewhat meant to be fragile.  If AlphaVantage changes their API, this library **will** likely break.
* But that will nearly guarantee that if this library gives you results, you can trust those results are full and accurate.