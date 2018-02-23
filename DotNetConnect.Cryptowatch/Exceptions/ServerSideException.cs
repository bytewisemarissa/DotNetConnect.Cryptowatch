using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConnect.Cryptowatch.Exceptions
{
    public class ServerSideException : Exception
    {
        public ServerSideException() : base("The cryptowatch api returned a 500. Try again later.") { }
    }
}
