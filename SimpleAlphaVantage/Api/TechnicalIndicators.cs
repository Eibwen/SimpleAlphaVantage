using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using SimpleAlphaVantage.Extensions;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.ResponseModels.TechnicalIndicatorModels;
using SimpleAlphaVantage.Utilities;
// ReSharper disable InconsistentNaming

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
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.SMA), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> EMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.EMA), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> WMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.WMA), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> DEMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.DEMA), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> TEMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.TEMA), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> TRIMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.TRIMA), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> KAMA(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.KAMA), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator<MesaAdaptiveMovingAverage>> MAMA(string symbol, TimeInterval interval, SeriesType seriesType, float fastlimit = 0.01f, float slowlimit = 0.01f)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator<MesaAdaptiveMovingAverage>>(BuildUri(ApiFunction.MAMA), new Dictionary<string, string>
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
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.T3), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator<Macd>> MACD(string symbol, TimeInterval interval, SeriesType seriesType, uint fastperiod = 12, uint slowperiod = 26, uint signalperiod = 9)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator<Macd>>(BuildUri(ApiFunction.MACD), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()},
                {"fastperiod", fastperiod.ToString()},
                {"slowperiod", slowperiod.ToString()},
                {"signalperiod", signalperiod.ToString()}
            });
        }

        public async Task<TechnicalIndicator<Macd>> MACDEXT(string symbol, TimeInterval interval, SeriesType seriesType, uint fastperiod = 12, uint slowperiod = 26, uint signalperiod = 9, MovingAverageType fastmatype = MovingAverageType.Simple, MovingAverageType slowmatype = MovingAverageType.Simple, MovingAverageType signalmatype = MovingAverageType.Simple)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator<Macd>>(BuildUri(ApiFunction.MACDEXT), new Dictionary<string, string>
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

        public async Task<TechnicalIndicator<StochasticSlow>> STOCH(string symbol, TimeInterval interval, uint fastkperiod = 5, uint slowkperiod = 3, uint slowdperiod = 3, MovingAverageType slowkmatype = MovingAverageType.Simple, MovingAverageType slowdmatype = MovingAverageType.Simple)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator<StochasticSlow>>(BuildUri(ApiFunction.STOCH), new Dictionary<string, string>
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

        public async Task<TechnicalIndicator<StochasticFast>> STOCHF(string symbol, TimeInterval interval, uint fastkperiod = 5, uint fastdperiod = 3, MovingAverageType fastdmatype = MovingAverageType.Simple)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator<StochasticFast>>(BuildUri(ApiFunction.STOCHF), new Dictionary<string, string>
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
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.RSI), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator<StochasticFast>> STOCHRSI(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType, uint fastkperiod = 5, uint fastdperiod = 3, MovingAverageType fastdmatype = MovingAverageType.Simple)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator<StochasticFast>>(BuildUri(ApiFunction.STOCHRSI), new Dictionary<string, string>
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
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.WILLR), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> ADX(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.ADX), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> ADXR(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.ADXR), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> APO(string symbol, TimeInterval interval, SeriesType seriesType, uint fastperiod = 12, uint slowperiod = 26, MovingAverageType matype = MovingAverageType.Simple)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.APO), new Dictionary<string, string>
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
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.PPO), new Dictionary<string, string>
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
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.MOM), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> BOP(string symbol, TimeInterval interval)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.BOP), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()}
            });
        }

        public async Task<TechnicalIndicator> CCI(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.CCI), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> CMO(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.CMO), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> ROC(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.ROC), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> ROCR(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.ROCR), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator<Aroon>> AROON(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator<Aroon>>(BuildUri(ApiFunction.AROON), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> AROONOSC(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.AROONOSC), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> MFI(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.MFI), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> TRIX(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.TRIX), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> ULTOSC(string symbol, TimeInterval interval, uint timeperiod1 = 7, uint timeperiod2 = 14, uint timeperiod3 = 28)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.ULTOSC), new Dictionary<string, string>
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
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.DX), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> MINUS_DI(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.MINUS_DI), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> PLUS_DI(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.PLUS_DI), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> MINUS_DM(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.MINUS_DM), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> PLUS_DM(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.PLUS_DM), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator<BollingerBands>> BBANDS(string symbol, TimeInterval interval, uint timePeriod, SeriesType seriesType, uint nbdevup = 2, uint nbdevdn = 2, MovingAverageType matype = MovingAverageType.Simple)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator<BollingerBands>>(BuildUri(ApiFunction.BBANDS), new Dictionary<string, string>
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
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.MIDPOINT), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> MIDPRICE(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.MIDPRICE), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> SAR(string symbol, TimeInterval interval, float acceleration = 0.01f, float maximum = 0.20f)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.SAR), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"acceleration", acceleration.ToString(CultureInfo.InvariantCulture)},
                {"maximum", maximum.ToString(CultureInfo.InvariantCulture)}
            });
        }

        public async Task<TechnicalIndicator> TRANGE(string symbol, TimeInterval interval)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.TRANGE), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()}
            });
        }

        public async Task<TechnicalIndicator> ATR(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.ATR), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> NATR(string symbol, TimeInterval interval, uint timePeriod)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.NATR), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"time_period", timePeriod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> AD(string symbol, TimeInterval interval)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.AD), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()}
            });
        }

        public async Task<TechnicalIndicator> ADOSC(string symbol, TimeInterval interval, uint fastperiod = 3, uint slowperiod = 10)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.ADOSC), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"fastperiod", fastperiod.ToString()},
                {"slowperiod", slowperiod.ToString()}
            });
        }

        public async Task<TechnicalIndicator> OBV(string symbol, TimeInterval interval)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.OBV), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()}
            });
        }

        public async Task<TechnicalIndicator> HT_TRENDLINE(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.HT_TRENDLINE), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator<HilbertTransformSine>> HT_SINE(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator<HilbertTransformSine>>(BuildUri(ApiFunction.HT_SINE), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> HT_TRENDMODE(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.HT_TRENDMODE), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> HT_DCPERIOD(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.HT_DCPERIOD), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator> HT_DCPHASE(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator>(BuildUri(ApiFunction.HT_DCPHASE), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }

        public async Task<TechnicalIndicator<HilbertTransformPhasor>> HT_PHASOR(string symbol, TimeInterval interval, SeriesType seriesType)
        {
            return await ApiClient.SendGetAsync<TechnicalIndicator<HilbertTransformPhasor>>(BuildUri(ApiFunction.HT_PHASOR), new Dictionary<string, string>
            {
                {"symbol", symbol},
                {"interval", interval.GetDescription()},
                {"series_type", seriesType.ToString()}
            });
        }
    }
}