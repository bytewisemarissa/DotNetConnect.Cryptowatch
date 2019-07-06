using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class Exchange
    {
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "routes")]
        public ExchangeRoutesCollection ExchangeRoutes { get; set; }
    }
}
