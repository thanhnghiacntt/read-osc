using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Iotlink.Converts
{
    public class JsonConverterObjectToList<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object[]);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IList<T> tag = new List<T>();

            if (reader.TokenType != JsonToken.Null)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    JToken token = JToken.Load(reader);
                    List<T> items = token.ToObject<List<T>>();
                    return items;
                }
                else
                {
                    JToken token = JToken.Load(reader);
                    var list = new List<T>()
                    {
                        token.ToObject<T>()
                    };
                    return list;
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteValue("");
        }
    }
}
