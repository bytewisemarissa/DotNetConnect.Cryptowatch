using HelpfulThings.Connect.Cryptowatch.Converters;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.DataModel
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
