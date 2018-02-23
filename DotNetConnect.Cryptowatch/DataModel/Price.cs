using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class Price
    {
        [JsonProperty(PropertyName = "price")]
        public decimal CurrentPrice { get; set; }
    }
}
