using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConnect.Cryptowatch.Exceptions
{
    public class ImplementationException : Exception
    {
        public ImplementationException() : base("The server returned 400 this library may be outdated. Check for updates.") { }
    }
}
