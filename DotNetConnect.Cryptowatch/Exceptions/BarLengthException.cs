using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConnect.Cryptowatch.Exceptions
{
    public class BarLengthException : Exception
    {
        public BarLengthException(string message) : base(message) { }
        public BarLengthException(string message, Exception innerException) : base(message, innerException) { }
    }
}
