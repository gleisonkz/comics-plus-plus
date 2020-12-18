using ComicStore.Domain.Interfaces;
using ComicStore.Shared.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComicStore.Application.DTO
{
    public class CustomJsonConverter<TInterface, TConcrete> : JsonConverter
        where TConcrete : TInterface, new()
    {
        public override bool CanConvert(Type objectType)
        {
            bool canConvert = objectType == typeof(IOrderItemDTO);
            return canConvert;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            // *** Deserialize the object to a temporary instance            
            JToken jsonToken = JToken.Load(reader);

            void Convert(object returnValue)
            {
                using JsonReader serializerReader = jsonToken.CreateReader();
                serializer.Populate(serializerReader, returnValue);
            }


            if (jsonToken is JObject)
            {
                TConcrete returnValue = new TConcrete();
                Convert(returnValue);
                return returnValue;

            }
            else if (jsonToken is JArray)
            {
                List<TConcrete> returnValue = new List<TConcrete>();
                Convert(returnValue);

                return returnValue.Select(c => (TInterface)c)
                                  .ToList();
            }

            throw new CustomException("Ocorreu um erro ao tentar realizar a conversão");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
