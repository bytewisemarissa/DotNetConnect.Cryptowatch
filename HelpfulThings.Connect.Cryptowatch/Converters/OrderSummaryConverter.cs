using System;
using System.Linq;
using HelpfulThings.Connect.Cryptowatch.DataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HelpfulThings.Connect.Cryptowatch.Converters
{
    public class OrderSummaryConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var order = (OrderSummary)value;
            serializer.Serialize(writer, new[] { order.Price, order.Amount });
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var array = JArray.Load(reader);
            var order = (existingValue as OrderSummary ?? new OrderSummary());
            order.Price = (decimal)array.ElementAtOrDefault(0);
            order.Amount = (decimal)array.ElementAtOrDefault(1);
            return order;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(OrderSummary);
        }
    }
}
