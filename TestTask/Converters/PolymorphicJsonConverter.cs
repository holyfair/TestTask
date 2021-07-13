using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repository.Models.Customer;
using System;

namespace TestTask.Converters
{
    public class PolymorphicJsonConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            var type = item["type"].Value<string>();

            if (type == "MrGreenCustomerModel")
            {
                return item.ToObject<MrGreenCustomerModel>();
            }
            else if (type == "RedBetCustomerModel")
            {
                return item.ToObject<RedBetCustomerModel>();
            }
            else
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject o = JObject.FromObject(value);
            if (value is MrGreenCustomerModel)
            {
                o.AddFirst(new JProperty("type", new JValue("MrGreenCustomerModel")));
            }
            else if (value is RedBetCustomerModel)
            {
                o.AddFirst(new JProperty("type", new JValue("RedBetCustomerModel")));
            }

            o.WriteTo(writer);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(CustomerModel).IsAssignableFrom(objectType);
        }
    }
}
