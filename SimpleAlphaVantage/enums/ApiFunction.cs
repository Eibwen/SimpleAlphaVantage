﻿namespace SimpleAlphaVantage.Enums
{
    // ReSharper disable InconsistentNaming
    /// <summary>
    /// Possible functions of Alpha Vantage API
    /// </summary>
    /// <remarks>Using work by https://github.com/LutsenkoKirill/AlphaVantage.Net </remarks>
    public enum ApiFunction
    {
        // Stock Time Series Data
        TIME_SERIES_INTRADAY,
        TIME_SERIES_DAILY,
        TIME_SERIES_DAILY_ADJUSTED,
        TIME_SERIES_WEEKLY,
        TIME_SERIES_WEEKLY_ADJUSTED,
        TIME_SERIES_MONTHLY,
        TIME_SERIES_MONTHLY_ADJUSTED,
        BATCH_STOCK_QUOTES,

        // Foreign Exchange (FX)
        CURRENCY_EXCHANGE_RATE,

        // Digital & Crypto Currencies
        DIGITAL_CURRENCY_INTRADAY,
        DIGITAL_CURRENCY_DAILY,
        DIGITAL_CURRENCY_WEEKLY,
        DIGITAL_CURRENCY_MONTHLY,

        // Stock Technical Indicators
        SMA,
        EMA,
        WMA,
        DEMA,
        TEMA,
        TRIMA,
        KAMA,
        MAMA,
        T3,
        MACD,
        MACDEXT,
        STOCH,
        STOCHF,
        RSI,
        STOCHRSI,
        WILLR,
        ADX,
        ADXR,
        APO,
        PPO,
        MOM,
        BOP,
        CCI,
        CMO,
        ROC,
        ROCR,
        AROON,
        AROONOSC,
        MFI,
        TRIX,
        ULTOSC,
        DX,
        MINUS_DI,
        PLUS_DI,
        MINUS_DM,
        PLUS_DM,
        BBANDS,
        MIDPOINT,
        MIDPRICE,
        SAR,
        TRANGE,
        ATR,
        NATR,
        AD,
        ADOSC,
        OBV,
        HT_TRENDLINE,
        HT_SINE,
        HT_TRENDMODE,
        HT_DCPERIOD,
        HT_DCPHASE,
        HT_PHASOR,

        // Sector Performances
        SECTOR
    }
}