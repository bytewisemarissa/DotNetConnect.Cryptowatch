using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class OrderBook
    {
        [JsonProperty(PropertyName = "asks")]
        public List<OrderSummary> Asks { get; set; }

        [JsonProperty(PropertyName = "bids")]
        public List<OrderSummary> Bids { get; set; }
    }
}