using System;

namespace HelpfulThings.Connect.Cryptowatch.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string uri) : base($"The resource requested was not found check your parameters and try again.(URI: {uri})") { }
    }
}
