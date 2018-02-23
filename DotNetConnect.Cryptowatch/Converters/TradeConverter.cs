using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetConnect.Cryptowatch.DataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotNetConnect.Cryptowatch.Converters
{
    public class TradeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var trade = (Trade)value;
            serializer.Serialize(writer, new[] { trade.Id, trade.TimestampTicks, trade.Price, trade.Amount });
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var array = JArray.Load(reader);
            var trade = (existingValue as Trade ?? new Trade());
            trade.Id = (long)array.ElementAtOrDefault(0);
            trade.TimestampTicks = (long)array.ElementAtOrDefault(1);
            trade.Price = (decimal)array.ElementAtOrDefault(2);
            trade.Amount = (decimal)array.ElementAtOrDefault(3);
            return trade;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Trade);
        }
    }
}
