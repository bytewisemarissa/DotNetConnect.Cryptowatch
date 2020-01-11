using System;

namespace HelpfulThings.Connect.Cryptowatch.Exceptions
{
    public class ServerSideException : Exception
    {
        public ServerSideException() : base("The cryptowatch api returned a 500. Try again later.") { }
    }
}
