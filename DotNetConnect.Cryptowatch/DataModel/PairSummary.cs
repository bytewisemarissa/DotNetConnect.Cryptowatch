using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class PairSummary
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
    }
}
