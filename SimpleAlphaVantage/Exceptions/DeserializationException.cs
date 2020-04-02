using System;

namespace SimpleAlphaVantage.Exceptions
{
    public class DeserializationException : AlphaVantageException
    {
        public string RawResponse { get; }

        public DeserializationException(string message, string rawResponse) : base(message)
        {
            RawResponse = rawResponse;
        }

        public DeserializationException(string message, string rawResponse, Exception innerException) : base(message, innerException)
        {
            RawResponse = rawResponse;
        }
    }
}