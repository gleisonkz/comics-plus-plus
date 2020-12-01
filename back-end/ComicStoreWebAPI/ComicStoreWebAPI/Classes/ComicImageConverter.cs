using ComicStore.Domain.Interfaces;
using Newtonsoft.Json;
using System;

namespace ComicStore.Application.DTO
{
    public class ComicImageConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            bool canConvert = objectType == typeof(IComicImageDTO);
            return canConvert;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(ComicImageDTO));
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
