using System;

namespace HelpfulThings.Connect.Cryptowatch.Exceptions
{
    public class ImplementationException : Exception
    {
        public ImplementationException() : base("The server returned 400 this library may be outdated. Check for updates.") { }
    }
}
