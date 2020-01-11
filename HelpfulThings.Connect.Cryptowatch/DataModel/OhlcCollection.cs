using System.Collections.Generic;
using HelpfulThings.Connect.Cryptowatch.Converters;
using HelpfulThings.Connect.Cryptowatch.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.DataModel
{
    [JsonConverter(typeof(OhlcCollectionConverter))]
    public class OhlcCollection : Dictionary<TimeBarLength, List<TimeBar>>
    {
    }
}
