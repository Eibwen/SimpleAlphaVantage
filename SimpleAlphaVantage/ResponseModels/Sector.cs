using Newtonsoft.Json;
using SimpleAlphaVantage.Utilities.SerializationClasses;

namespace SimpleAlphaVantage.ResponseModels
{
    public class Sector
    {
        [JsonProperty("Meta Data")]
        public SectorMetadata Metadata { get; set; }

        [JsonProperty("Rank A: Real-Time Performance")]
        public SectorPerformance PerformanceRealTime { get; set; }
        [JsonProperty("Rank B: 1 Day Performance")]
        public SectorPerformance Performance1Day { get; set; }
        [JsonProperty("Rank C: 5 Day Performance")]
        public SectorPerformance Performance5Day { get; set; }
        [JsonProperty("Rank D: 1 Month Performance")]
        public SectorPerformance Performance1Month { get; set; }
        [JsonProperty("Rank E: 3 Month Performance")]
        public SectorPerformance Performance3Month { get; set; }
        [JsonProperty("Rank F: Year-to-Date (YTD) Performance")]
        public SectorPerformance PerformanceYTD { get; set; }
        [JsonProperty("Rank G: 1 Year Performance")]
        public SectorPerformance Performance1Year { get; set; }
        [JsonProperty("Rank H: 3 Year Performance")]
        public SectorPerformance Performance3Year { get; set; }
        [JsonProperty("Rank I: 5 Year Performance")]
        public SectorPerformance Performance5Year { get; set; }
        [JsonProperty("Rank J: 10 Year Performance")]
        public SectorPerformance Performance10Year { get; set; }
    }

    public class SectorMetadata
    {
        public string Information { get; set; }
        //TODO parse this funcky format into a DateTimeOffset
        [JsonProperty("Last Refreshed")]
        public string LastRefreshed { get; set; }
    }

    /// <summary>
    /// These are all percentages, so if doing math with them, divide by 100 first!
    /// </summary>
    public class SectorPerformance
    {
        [JsonProperty("Health Care")]
        [JsonConverter(typeof(PercentageJsonConverter))]
        public double HealthCare { get; set; }
        [JsonProperty("Utilities")]
        [JsonConverter(typeof(PercentageJsonConverter))]
        public double Utilities { get; set; }
        [JsonProperty("Information Technology")]
        [JsonConverter(typeof(PercentageJsonConverter))]
        public double InformationTechnology { get; set; }
        [JsonProperty("Real Estate")]
        [JsonConverter(typeof(PercentageJsonConverter))]
        public double RealEstate { get; set; }
        [JsonProperty("Telecommunication Services")]
        [JsonConverter(typeof(PercentageJsonConverter))]
        public double TelecommunicationServices { get; set; }
        [JsonProperty("Consumer Staples")]
        [JsonConverter(typeof(PercentageJsonConverter))]
        public double ConsumerStaples { get; set; }
        [JsonProperty("Consumer Discretionary")]
        [JsonConverter(typeof(PercentageJsonConverter))]
        public double ConsumerDiscretionary { get; set; }
        [JsonProperty("Industrials")]
        [JsonConverter(typeof(PercentageJsonConverter))]
        public double Industrials { get; set; }
        [JsonProperty("Materials")]
        [JsonConverter(typeof(PercentageJsonConverter))]
        public double Materials { get; set; }
        [JsonProperty("Energy")]
        [JsonConverter(typeof(PercentageJsonConverter))]
        public double Energy { get; set; }
        [JsonProperty("Financials")]
        [JsonConverter(typeof(PercentageJsonConverter))]
        public double Financials { get; set; }
    }
}