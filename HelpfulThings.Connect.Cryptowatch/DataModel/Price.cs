using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.DataModel
{
    public class Price
    {
        [JsonProperty(PropertyName = "price")]
        public decimal CurrentPrice { get; set; }
    }
}
