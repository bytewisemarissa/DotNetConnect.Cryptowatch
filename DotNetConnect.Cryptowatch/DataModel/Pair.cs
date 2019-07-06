using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
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
