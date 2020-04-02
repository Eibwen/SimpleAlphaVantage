using Newtonsoft.Json;

namespace SimpleAlphaVantage.ResponseModels
{
    public class ErrorResponse
    {
        [JsonProperty("Error Message")]
        public string ErrorMessage { get; set; }
    }
}