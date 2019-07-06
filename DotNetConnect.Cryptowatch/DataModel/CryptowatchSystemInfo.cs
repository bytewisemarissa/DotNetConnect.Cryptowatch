using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    public class CryptowatchSystemInfo
    {
        [JsonProperty(PropertyName = "revision")]
        public string Revision { get; set; }

        [JsonProperty(PropertyName = "uptime")]
        public string UpTime { get; set; }

        [JsonProperty(PropertyName = "documentation")]
        public Uri DocumentationUrl { get; set; }

        [JsonProperty(PropertyName = "indexes")]
        public List<Uri> Indexes { get; set; }
    }
}
