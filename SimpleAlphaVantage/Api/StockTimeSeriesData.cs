using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SimpleAlphaVantage.Extensions;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantage.Api
{
    public class StockTimeSeriesData
    {
        private readonly string _apiKey;
        private readonly GenericApiClient _apiClient;

        private readonly DataFormat _dataFormat = DataFormat.json;

        public StockTimeSeriesData(string apiKey, GenericApiClient apiClient = null)
        {
            _apiKey = apiKey;
            _apiClient = apiClient ?? new GenericApiClient(ConfigureClient);
        }

        protected void ConfigureClient(HttpClient client)
        {
            //client.DefaultRequestHeaders
            //    .Accept
            //    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected Uri BuildUri(ApiFunction function)
        {
            return new Uri($"https://www.alphavantage.co/query?function={function}&apikey={_apiKey}&datatype={_dataFormat}");
        }

        /// <summary>
        /// This API returns intraday time series (timestamp, open, high, low, close, volume) of the equity specified, updated realtime.
        /// </summary>
        public async Task<TimeSeriesIntraday> TimeSeriesIntraday(string symbol, IntradayInterval interval, OutputType output = OutputType.Latest100)
        {
            var function = ApiFunction.TIME_SERIES_INTRADAY;

            return await _apiClient.SendGetAsync<TimeSeriesIntraday>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"outputsize", output.GetDescription()}
            });
        }

        public async Task<TimeSeriesDaily> TimeSeriesDaily(string symbol, OutputType output = OutputType.Latest100)
        {
            var function = ApiFunction.TIME_SERIES_DAILY;

            return await _apiClient.SendGetAsync<TimeSeriesDaily>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"outputsize", output.GetDescription()}
            });
        }

        public async Task<TimeSeriesDailyAdjusted> TimeSeriesDailyAdjusted(string symbol, OutputType output = OutputType.Latest100)
        {
            var function = ApiFunction.TIME_SERIES_DAILY_ADJUSTED;

            return await _apiClient.SendGetAsync<TimeSeriesDailyAdjusted>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"outputsize", output.GetDescription()}
            });
        }

        public async Task<TimeSeriesWeekly> TimeSeriesWeekly(string symbol)
        {
            var function = ApiFunction.TIME_SERIES_WEEKLY;

            return await _apiClient.SendGetAsync<TimeSeriesWeekly>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol}
            });
        }

        public async Task<TimeSeriesWeeklyAdjusted> TimeSeriesWeeklyAdjusted(string symbol)
        {
            var function = ApiFunction.TIME_SERIES_WEEKLY_ADJUSTED;

            return await _apiClient.SendGetAsync<TimeSeriesWeeklyAdjusted>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol}
            });
        }

        public async Task<TimeSeriesMonthly> TimeSeriesMonthly(string symbol)
        {
            var function = ApiFunction.TIME_SERIES_MONTHLY;

            return await _apiClient.SendGetAsync<TimeSeriesMonthly>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol}
            });
        }

        public async Task<TimeSeriesMonthlyAdjusted> TimeSeriesMonthlyAdjusted(string symbol)
        {
            var function = ApiFunction.TIME_SERIES_MONTHLY_ADJUSTED;

            return await _apiClient.SendGetAsync<TimeSeriesMonthlyAdjusted>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol}
            });
        }

        public async Task<BatchStockQuotes> BatchStockQuotes(params string[] symbols)
        {
            var function = ApiFunction.BATCH_STOCK_QUOTES;

            if (symbols.Length > 100)
            {
                throw new Exception("The API supports a maximum batch size of 100");
            }

            return await _apiClient.SendGetAsync<BatchStockQuotes>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", string.Join(",", symbols)}
            });
        }
    }
}