using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class MarketsCollection
    {
        [JsonProperty(PropertyName = "base")]
        public List<MarketSummary> Base { get; set; }

        [JsonProperty(PropertyName = "quote")]
        public List<MarketSummary> Quote { get; set; }
    }
}
