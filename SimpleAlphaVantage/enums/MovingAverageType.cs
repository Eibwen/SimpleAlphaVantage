namespace SimpleAlphaVantage.Enums
{
    public enum MovingAverageType
    {
        /// <summary>
        /// Simple Moving Average (SMA)
        /// </summary>
        Simple = 0,
        /// <summary>
        /// Exponential Moving Average (EMA)
        /// </summary>
        Exponential = 1,
        /// <summary>
        /// Weighted Moving Average (WMA)
        /// </summary>
        Weighted = 2,
        /// <summary>
        /// Double Exponential Moving Average (DEMA)
        /// </summary>
        DoubleExponential = 3,
        /// <summary>
        /// Triple Exponential Moving Average (TEMA)
        /// </summary>
        TripleExponential = 4,
        /// <summary>
        /// Triangular Moving Average (TRIMA)
        /// </summary>
        Triangular = 5,
        /// <summary>
        /// T3 Moving Average
        /// </summary>
        T3 = 6,
        /// <summary>
        /// Kaufman Adaptive Moving Average (KAMA)
        /// </summary>
        KaufmanAdaptive = 7,
        /// <summary>
        /// MESA Adaptive Moving Average (MAMA)
        /// </summary>
        MESAAdaptive = 8,
    }
}