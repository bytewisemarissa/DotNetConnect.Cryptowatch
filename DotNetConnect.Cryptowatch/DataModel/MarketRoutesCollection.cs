using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class MarketRoutesCollection
    {
        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "orderbook")]
        public string OrderBook { get; set; }

        [JsonProperty(PropertyName = "trades")]
        public string Trades { get; set; }

        [JsonProperty(PropertyName = "ohlc")]
        public string Ohlc { get; set; }
    }
}
