using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class Summary
    {
        [JsonProperty(PropertyName = "price")]
        public PriceSummary Price { get; set; }

        [JsonProperty(PropertyName = "Volume")]
        public decimal Volume { get; set; }

        [JsonProperty(PropertyName = "volumeQuote")]
        public long VolumeQuote { get; set; }
    }
}
