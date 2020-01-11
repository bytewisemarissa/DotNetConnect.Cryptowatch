using System;

namespace HelpfulThings.Connect.Cryptowatch.Extensions
{
    public static class LongExtensions
    {
        public static DateTime GetDateFromUnixTimeStamp(this long stamp)
        {
            return new DateTime(1970, 1, 1).ToUniversalTime().AddSeconds(stamp);
        }
    }
}
