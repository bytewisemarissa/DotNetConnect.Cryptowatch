using System;
using System.Collections.Generic;
using System.Text;
using DotNetConnect.Cryptowatch.Converters;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    [JsonConverter(typeof(TimeBarConverter))]
    public class TimeBar
    {
        public DateTime CloseTimeUtc { get; set; }
        public Decimal OpenPrice { get; set; }
        public Decimal HighPrice { get; set; }
        public Decimal LowPrice { get; set;}
        public Decimal ClosePrice { get; set; }
        public Decimal Volume { get; set; }
    }
}
