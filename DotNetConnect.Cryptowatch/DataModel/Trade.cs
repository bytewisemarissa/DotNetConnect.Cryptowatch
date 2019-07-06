using System;
using System.Collections.Generic;
using System.Text;
using DotNetConnect.Cryptowatch.Converters;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    [JsonConverter(typeof(TradeConverter))]
    public class Trade
    {
        public long Id { get; set; }
        public long TimestampTicks { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}
