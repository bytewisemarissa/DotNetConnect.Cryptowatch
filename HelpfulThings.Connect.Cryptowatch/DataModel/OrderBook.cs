using System.Collections.Generic;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.DataModel
{
    public class OrderBook
    {
        [JsonProperty(PropertyName = "asks")]
        public List<OrderSummary> Asks { get; set; }

        [JsonProperty(PropertyName = "bids")]
        public List<OrderSummary> Bids { get; set; }
    }
}