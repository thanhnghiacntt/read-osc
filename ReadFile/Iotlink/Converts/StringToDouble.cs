using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Iotlink.Converts
{
    public class StringToDouble: JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object[]);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Null)
            {
                if (reader.TokenType == JsonToken.String)
                {
                    JToken token = JToken.Load(reader);
                    return token.ToObject<double>();
                }
            }
            return 0;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteValue("");
        }
    }
}
