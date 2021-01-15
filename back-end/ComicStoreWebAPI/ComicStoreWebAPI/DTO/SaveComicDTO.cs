using ComicStore.Domain.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ComicStore.Application.DTO
{
    public class SaveComicDTO : ISaveComicDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [JsonConverter(typeof(CustomJsonConverter<IComicImageDTO, ComicImageDTO>))]
        public IComicImageDTO Image { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        public int[] Authors { get; set; }
        [Required]
        public int[] Genres { get; set; }
    }
}
