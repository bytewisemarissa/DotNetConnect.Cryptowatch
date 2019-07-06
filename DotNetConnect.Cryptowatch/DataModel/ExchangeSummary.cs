using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class ExchangeSummary
    {
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "route")]
        public string Route { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }
    }
}
