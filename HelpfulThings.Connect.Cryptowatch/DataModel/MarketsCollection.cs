using System.Collections.Generic;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.DataModel
{
    public class MarketsCollection
    {
        [JsonProperty(PropertyName = "base")]
        public List<MarketSummary> Base { get; set; }

        [JsonProperty(PropertyName = "quote")]
        public List<MarketSummary> Quote { get; set; }
    }
}
