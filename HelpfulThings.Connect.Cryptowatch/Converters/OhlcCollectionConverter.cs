using System;
using System.Collections.Generic;
using HelpfulThings.Connect.Cryptowatch.DataModel;
using HelpfulThings.Connect.Cryptowatch.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch.Converters
{
    public class OhlcCollectionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var ohlcCollection = (OhlcCollection)value;

            Dictionary<long, List<TimeBar>> returnValue = new Dictionary<long, List<TimeBar>>();
            foreach (var timebarlength in ohlcCollection)
            {
                returnValue.Add(timebarlength.Key.LengthInSeconds, timebarlength.Value);
            }
            
            serializer.Serialize(writer, returnValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            OhlcCollection returnValue =
            (existingValue as OhlcCollection ??
             new OhlcCollection());

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    //convert property name to time span
                    var barLength = TimeBarLength.GetBarLengthFromSeconds(Convert.ToString(reader.Value));

                    //clear open length collection
                    reader.Read();
                    //ensure open collection
                    if (reader.TokenType != JsonToken.StartArray)
                        throw new ApplicationException();

                    reader.Read();

                    List<TimeBar> bars = new List<TimeBar>();
                    while (reader.TokenType == JsonToken.StartArray)
                    {
                        var timebar = serializer.Deserialize<TimeBar>(reader);
                        bars.Add(timebar);
                        //read past timebar end
                        reader.Read();
                    }

                    returnValue.Add(barLength, bars);
                }

                if (reader.TokenType == JsonToken.EndObject)
                    break;
            }

            return returnValue;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(OhlcCollection);
        }
    }
}
