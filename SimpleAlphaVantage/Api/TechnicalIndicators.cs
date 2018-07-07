using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using SimpleAlphaVantage.Extensions;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantage.Api
{
    public class TechnicalIndicators : BaseEndpointParameters
    {
        public TechnicalIndicators(string apiKey, GenericApiClient apiClient = null)
            : base(apiKey, apiClient)
        {
        }

        public async Task<TechnicalIndicator> SMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.SMA;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> EMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.EMA;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> WMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.WMA;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> DEMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.DEMA;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> TEMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.TEMA;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> TRIMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.TRIMA;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> KAMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.KAMA;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> MAMA(string symbol, TimeInterval interval, SeriesType seriesType, float fastlimit = 0.01f, float slowlimit = 0.01f)
        {
            var function = ApiFunction.MAMA;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()},
                {"fastlimit", fastlimit.ToString(CultureInfo.InvariantCulture)},
                {"slowlimit", slowlimit.ToString(CultureInfo.InvariantCulture)}
            });
        }

        public async Task<TechnicalIndicator> T3(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.T3;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> MACD(string symbol, TimeInterval interval, SeriesType seriesType, uint fastperiod = 12, uint slowperiod = 26, uint signalperiod = 9)
        {
            var function = ApiFunction.MACD;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()},
                {"fastperiod", fastperiod.ToString()},
                {"slowperiod", slowperiod.ToString()},
                {"signalperiod", signalperiod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> MACDEXT(string symbol, TimeInterval interval, SeriesType seriesType, uint fastperiod = 12, uint slowperiod = 26, uint signalperiod = 9, MovingAverageType fastmatype = MovingAverageType.Simple, MovingAverageType slowmatype = MovingAverageType.Simple, MovingAverageType signalmatype = MovingAverageType.Simple)
        {
            var function = ApiFunction.MACDEXT;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()},
                {"fastperiod", fastperiod.ToString()},
                {"slowperiod", slowperiod.ToString()},
                {"signalperiod", signalperiod.ToString()},
                {"fastmatype", ((int)fastmatype).ToString()},
                {"slowmatype", ((int)slowmatype).ToString()},
                {"signalmatype", ((int)signalmatype).ToString()}
            });
        }

        public async Task<TechnicalIndicator> STOCH(string symbol, TimeInterval interval, uint fastkperiod = 5, uint slowkperiod = 3, uint slowdperiod = 3, MovingAverageType slowkmatype = MovingAverageType.Simple, MovingAverageType slowdmatype = MovingAverageType.Simple)
        {
            var function = ApiFunction.STOCH;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"fastkperiod", fastkperiod.ToString()},
                {"slowkperiod", slowkperiod.ToString()},
                {"slowdperiod", slowdperiod.ToString()},
                {"slowkmatype", ((int)slowkmatype).ToString()},
                {"slowdmatype", ((int)slowdmatype).ToString()}
            });
        }

        public async Task<TechnicalIndicator> STOCHF(string symbol, TimeInterval interval, uint fastkperiod = 5, uint fastdperiod = 3, MovingAverageType fastdmatype = MovingAverageType.Simple)
        {
            var function = ApiFunction.STOCHF;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"fastkperiod", fastkperiod.ToString()},
                {"fastdperiod", fastdperiod.ToString()},
                {"fastdmatype", ((int)fastdmatype).ToString()}
            });
        }

        public async Task<TechnicalIndicator> RSI(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.RSI;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> STOCHRSI(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType, uint fastkperiod = 5, uint fastdperiod = 3, MovingAverageType fastdmatype = MovingAverageType.Simple)
        {
            var function = ApiFunction.STOCHRSI;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()},
                {"fastkperiod", fastkperiod.ToString()},
                {"fastdperiod", fastdperiod.ToString()},
                {"fastdmatype", ((int)fastdmatype).ToString()}
            });
        }

        public async Task<TechnicalIndicator> WILLR(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.WILLR;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> ADX(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.ADX;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> ADXR(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.ADXR;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> APO(string symbol, TimeInterval interval, SeriesType seriesType, uint fastperiod = 12, uint slowperiod = 26, MovingAverageType matype = MovingAverageType.Simple)
        {
            var function = ApiFunction.APO;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()},
                {"fastperiod", fastperiod.ToString()},
                {"slowperiod", slowperiod.ToString()},
                {"matype", ((int)matype).ToString()}
            });
        }

        public async Task<TechnicalIndicator> PPO(string symbol, TimeInterval interval, SeriesType seriesType, uint fastperiod = 12, uint slowperiod = 26, MovingAverageType matype = MovingAverageType.Simple)
        {
            var function = ApiFunction.PPO;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()},
                {"fastperiod", fastperiod.ToString()},
                {"slowperiod", slowperiod.ToString()},
                {"matype", ((int)matype).ToString()}
            });
        }

        public async Task<TechnicalIndicator> MOM(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.MOM;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> BOP(string symbol, TimeInterval interval)
        {
            var function = ApiFunction.BOP;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()}
            });
        }

        public async Task<TechnicalIndicator> CCI(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.CCI;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> CMO(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.CMO;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> ROC(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.ROC;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> ROCR(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.ROCR;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> AROON(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.AROON;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> AROONOSC(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.AROONOSC;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> MFI(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.MFI;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> TRIX(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.TRIX;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> ULTOSC(string symbol, TimeInterval interval, uint timeperiod1 = 7, uint timeperiod2 = 14, uint timeperiod3 = 28)
        {
            var function = ApiFunction.ULTOSC;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"timeperiod1", timeperiod1.ToString()},
                {"timeperiod2", timeperiod2.ToString()},
                {"timeperiod3", timeperiod3.ToString()}
            });
        }

        public async Task<TechnicalIndicator> DX(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.DX;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> MINUS_DI(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.MINUS_DI;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> PLUS_DI(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.PLUS_DI;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> MINUS_DM(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.MINUS_DM;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> PLUS_DM(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.PLUS_DM;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> BBANDS(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType, uint nbdevup = 2, uint nbdevdn = 2, MovingAverageType matype = MovingAverageType.Simple)
        {
            var function = ApiFunction.BBANDS;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()},
                {"nbdevup", nbdevup.ToString()},
                {"nbdevdn", nbdevdn.ToString()},
                {"matype", ((int)matype).ToString()}
            });
        }

        public async Task<TechnicalIndicator> MIDPOINT(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            var function = ApiFunction.MIDPOINT;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> MIDPRICE(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.MIDPRICE;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> SAR(string symbol, TimeInterval interval, float acceleration = 0.01f, float maximum = 0.20f)
        {
            var function = ApiFunction.SAR;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"acceleration", acceleration.ToString(CultureInfo.InvariantCulture)},
                {"maximum", maximum.ToString(CultureInfo.InvariantCulture)}
            });
        }

        public async Task<TechnicalIndicator> TRANGE(string symbol, TimeInterval interval)
        {
            var function = ApiFunction.TRANGE;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()}
            });
        }

        public async Task<TechnicalIndicator> ATR(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.ATR;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> NATR(string symbol, TimeInterval interval, uint timePeriod)
        {
            var function = ApiFunction.NATR;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> AD(string symbol, TimeInterval interval)
        {
            var function = ApiFunction.AD;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()}
            });
        }

        public async Task<TechnicalIndicator> ADOSC(string symbol, TimeInterval interval, uint fastperiod = 3, uint slowperiod = 10)
        {
            var function = ApiFunction.ADOSC;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"fastperiod", fastperiod.ToString()},
                {"slowperiod", slowperiod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> OBV(string symbol, TimeInterval interval)
        {
            var function = ApiFunction.OBV;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()}
            });
        }

        public async Task<TechnicalIndicator> HT_TRENDLINE(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            var function = ApiFunction.HT_TRENDLINE;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> HT_SINE(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            var function = ApiFunction.HT_SINE;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> HT_TRENDMODE(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            var function = ApiFunction.HT_TRENDMODE;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> HT_DCPERIOD(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            var function = ApiFunction.HT_DCPERIOD;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> HT_DCPHASE(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            var function = ApiFunction.HT_DCPHASE;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> HT_PHASOR(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            var function = ApiFunction.HT_PHASOR;

            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(function), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }
    }
}