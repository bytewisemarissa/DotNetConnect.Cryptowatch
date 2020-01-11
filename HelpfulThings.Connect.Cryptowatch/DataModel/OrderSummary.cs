using HelpfulThings.Connect.Cryptowatch.Converters;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.DataModel
{
    [JsonConverter(typeof(OrderSummaryConverter))]
    public class OrderSummary
    {
        public decimal Price { get; set; }
        
        public decimal Amount { get; set; }
    }
}
