using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class Asset
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "fiat")]
        public bool IsFiatCurrency { get; set; }

        [JsonProperty(PropertyName = "markets")]
        public MarketsCollection Markets { get; set; }
    }
}
