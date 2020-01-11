using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.DataModel
{
    public class CryptowatchResponse<T>
    {
        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("allowance")]
        public Allowance Allowance { get; set; }
    }
}
