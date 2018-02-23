using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class PriceChangeSummary
    {
        [JsonProperty(PropertyName = "percentage")]
        public decimal Percentage { get; set; }

        [JsonProperty(PropertyName = "absolute")]
        public decimal Absolute { get; set; }
    }
}
