using System;
using System.Collections.Generic;
using System.Text;
using DotNetConnect.Cryptowatch.Converters;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch.DataModel
{
    [JsonConverter(typeof(OrderSummaryConverter))]
    public class OrderSummary
    {
        public decimal Price { get; set; }
        
        public decimal Amount { get; set; }
    }
}
