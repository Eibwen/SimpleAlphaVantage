using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace SimpleAlphaVantage.Exceptions
{
    [Serializable]
    public class AlphaVantageException : Exception
    {
        public AlphaVantageException()
        {
        }

        protected AlphaVantageException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public AlphaVantageException(string message)
            : base(message)
        {
        }

        public AlphaVantageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}