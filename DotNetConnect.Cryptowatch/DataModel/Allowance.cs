using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class Allowance
    {
        [JsonProperty("cost")]
        public long Cost { get; set; }

        [JsonProperty("remaining")]
        public long Remaining { get; set; }
    }
}
