using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleAlphaVantage.Enums;
using SimpleAlphaVantage.Extensions;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantage.Api
{
    public class StockTimeSeriesData : BaseEndpointParameters
    {
        public StockTimeSeriesData(string apiKey, GenericApiClient apiClient = null)
            : base(apiKey, apiClient)
        {
        }

        /// <summary>
        /// This API returns intraday time series (timestamp, open, high, low, close, volume) of the equity specified, updated realtime.
        /// </summary>
        public async Task<TimeSeriesIntraday> TimeSeriesIntraday(string symbol, IntradayInterval interval, OutputType output = OutputType.Latest100)
        {
            var function = ApiFunction.TIME_SERIES_INTRADAY;

            return await ApiClient.SendGetAsync<TimeSeriesIntraday>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"outputsize", output.GetDescription()}
            });
        }

        /// <summary>
        /// This API returns daily time series (date, daily open, daily high, daily low, daily close, daily volume) of the equity specified, covering up to 20 years of historical data.
        ///
        /// The most recent data point is the cumulative prices and volume information of the current trading day, updated realtime.
        /// </summary>
        public async Task<TimeSeriesDaily> TimeSeriesDaily(string symbol, OutputType output = OutputType.Latest100)
        {
            var function = ApiFunction.TIME_SERIES_DAILY;

            return await ApiClient.SendGetAsync<TimeSeriesDaily>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"outputsize", output.GetDescription()}
            });
        }

        /// <summary>
        /// This API returns daily time series (date, daily open, daily high, daily low, daily close, daily volume, daily adjusted close, and split/dividend events) of the equity specified, covering up to 20 years of historical data.
        ///
        /// The most recent data point is the cumulative prices and volume information of the current trading day, updated realtime.
        /// </summary>
        public async Task<TimeSeriesDailyAdjusted> TimeSeriesDailyAdjusted(string symbol, OutputType output = OutputType.Latest100)
        {
            var function = ApiFunction.TIME_SERIES_DAILY_ADJUSTED;

            return await ApiClient.SendGetAsync<TimeSeriesDailyAdjusted>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"outputsize", output.GetDescription()}
            });
        }

        /// <summary>
        /// This API returns weekly time series (last trading day of each week, weekly open, weekly high, weekly low, weekly close, weekly volume) of the equity specified, covering up to 20 years of historical data.
        ///
        /// The latest data point is the cumulative prices and volume information for the week(or partial week) that contains the current trading day, updated realtime.
        /// </summary>
        public async Task<TimeSeriesWeekly> TimeSeriesWeekly(string symbol)
        {
            var function = ApiFunction.TIME_SERIES_WEEKLY;

            return await ApiClient.SendGetAsync<TimeSeriesWeekly>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol}
            });
        }

        /// <summary>
        /// This API returns weekly adjusted time series (last trading day of each week, weekly open, weekly high, weekly low, weekly close, weekly adjusted close, weekly volume, weekly dividend) of the equity specified, covering up to 20 years of historical data.
        ///
        /// The latest data point is the cumulative prices and volume information for the week(or partial week) that contains the current trading day, updated realtime.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<TimeSeriesWeeklyAdjusted> TimeSeriesWeeklyAdjusted(string symbol)
        {
            var function = ApiFunction.TIME_SERIES_WEEKLY_ADJUSTED;

            return await ApiClient.SendGetAsync<TimeSeriesWeeklyAdjusted>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol}
            });
        }

        /// <summary>
        /// This API returns monthly time series (last trading day of each month, monthly open, monthly high, monthly low, monthly close, monthly volume) of the equity specified, covering up to 20 years of historical data.
        ///
        /// The latest data point is the cumulative prices and volume information for the month(or partial month) that contains the current trading day, updated realtime.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<TimeSeriesMonthly> TimeSeriesMonthly(string symbol)
        {
            var function = ApiFunction.TIME_SERIES_MONTHLY;

            return await ApiClient.SendGetAsync<TimeSeriesMonthly>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol}
            });
        }

        /// <summary>
        /// This API returns monthly adjusted time series (last trading day of each month, monthly open, monthly high, monthly low, monthly close, monthly adjusted close, monthly volume, monthly dividend) of the equity specified, covering up to 20 years of historical data.
        ///
        /// The latest data point is the cumulative prices and volume information for the month(or partial month) that contains the current trading day, updated realtime.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<TimeSeriesMonthlyAdjusted> TimeSeriesMonthlyAdjusted(string symbol)
        {
            var function = ApiFunction.TIME_SERIES_MONTHLY_ADJUSTED;

            return await ApiClient.SendGetAsync<TimeSeriesMonthlyAdjusted>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol}
            });
        }

        /// <summary>
        /// The batch stock quotes API enables the querying of multiple stock quotes with a single API request, updated realtime. It may serve as a lightweight alternative to our core stock time series APIs above (which have richer content but are symbol-specific).
        ///
        /// Given the specifications of our data provider(IEX), we currently only offer US stock quotes during US market hours through this API.If you would like to query international stocks, ETFs, and mutual funds traded on major global exchanges, please refer to our core stock time series APIs(Intraday, Daily, Daily Adjusted, Weekly, Weekly Adjusted, Monthly, and Monthly Adjusted).
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        public async Task<BatchStockQuotes> BatchStockQuotes(params string[] symbols)
        {
            var function = ApiFunction.BATCH_STOCK_QUOTES;

            if (symbols.Length > 100)
            {
                throw new Exception("The API supports a maximum batch size of 100");
            }

            return await ApiClient.SendGetAsync<BatchStockQuotes>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", string.Join(",", symbols)}
            });
        }
    }
}