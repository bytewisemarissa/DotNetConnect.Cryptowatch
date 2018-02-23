using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetConnect.Cryptowatch.DataModel;
using DotNetConnect.Cryptowatch.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotNetConnect.Cryptowatch.Converters
{
    public class TimeBarConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var timeBar = (TimeBar)value;
            serializer.Serialize(writer, new[]
            {
                timeBar.CloseTimeUtc.GetUnixTimeStamp(),
                timeBar.OpenPrice,
                timeBar.HighPrice,
                timeBar.LowPrice,
                timeBar.ClosePrice,
                timeBar.Volume
            });
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var array = JArray.Load(reader);
            var timeBar = (existingValue as TimeBar ?? new TimeBar());
            timeBar.CloseTimeUtc = ((long)array.ElementAtOrDefault(0)).GetDateFromUnixTimeStamp();
            timeBar.OpenPrice = (long)array.ElementAtOrDefault(1);
            timeBar.HighPrice = (decimal)array.ElementAtOrDefault(2);
            timeBar.LowPrice = (decimal)array.ElementAtOrDefault(3);
            timeBar.ClosePrice = (decimal)array.ElementAtOrDefault(4);
            timeBar.Volume = (decimal)array.ElementAtOrDefault(5);
            return timeBar;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeBar);
        }
    }
}
