using System;
using System.Collections.Generic;
using System.Text;
using DotNetConnect.Cryptowatch.Converters;
using DotNetConnect.Cryptowatch.Enums;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    [JsonConverter(typeof(OhlcCollectionConverter))]
    public class OhlcCollection : Dictionary<TimeBarLength, List<TimeBar>>
    {
    }
}
