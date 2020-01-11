using System;

namespace HelpfulThings.Connect.Cryptowatch.Extensions
{
    public static class DateTimeExtension
    {
        public static long GetUnixTimeStamp(this DateTime datetime)
        {
            return (long)datetime.Subtract(new DateTime(1970, 1, 1).ToUniversalTime()).TotalSeconds;
        }
    }
}