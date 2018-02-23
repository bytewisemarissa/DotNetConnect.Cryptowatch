using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class ExchangeRoutesCollection
    {
        [JsonProperty(PropertyName = "markets")]
        public string Markets { get; set; }
    }
}
