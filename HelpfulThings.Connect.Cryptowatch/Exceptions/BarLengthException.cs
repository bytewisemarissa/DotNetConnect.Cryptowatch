using System;

namespace HelpfulThings.Connect.Cryptowatch.Exceptions
{
    public class BarLengthException : Exception
    {
        public BarLengthException(string message) : base(message) { }
        public BarLengthException(string message, Exception innerException) : base(message, innerException) { }
    }
}
