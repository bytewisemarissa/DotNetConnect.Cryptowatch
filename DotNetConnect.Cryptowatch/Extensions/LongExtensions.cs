using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConnect.Cryptowatch.Extensions
{
    public static class LongExtensions
    {
        public static DateTime GetDateFromUnixTimeStamp(this long stamp)
        {
            return new DateTime(1970, 1, 1).ToUniversalTime().AddSeconds(stamp);
        }
    }
}
