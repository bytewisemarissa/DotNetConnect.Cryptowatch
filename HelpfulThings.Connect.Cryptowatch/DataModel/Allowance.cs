using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.DataModel
{
    public class Allowance
    {
        [JsonProperty("cost")]
        public long Cost { get; set; }

        [JsonProperty("remaining")]
        public long Remaining { get; set; }
    }
}
