using System;
using HelpfulThings.Connect.Cryptowatch.Converters;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.DataModel
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
