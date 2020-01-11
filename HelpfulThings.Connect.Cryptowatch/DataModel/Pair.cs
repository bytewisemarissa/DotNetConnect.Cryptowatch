using System.Collections.Generic;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.DataModel
{
    public class Pair
    {
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "base")]
        public AssetSummary BaseAsset { get; set; }

        [JsonProperty(PropertyName = "quote")]
        public AssetSummary QuoteAsset { get; set; }

        [JsonProperty(PropertyName = "route")]
        public string Route { get; set; }
        
        [JsonProperty(PropertyName = "markets")]
        public List<MarketSummary> Markets { get; set; }
    }
}
