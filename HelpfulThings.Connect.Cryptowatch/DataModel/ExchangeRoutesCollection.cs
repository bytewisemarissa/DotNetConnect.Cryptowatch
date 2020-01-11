using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.DataModel
{
    public class ExchangeRoutesCollection
    {
        [JsonProperty(PropertyName = "markets")]
        public string Markets { get; set; }
    }
}
