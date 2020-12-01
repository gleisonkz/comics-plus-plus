using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ComicStore.Domain.Interfaces
{
    public interface IComicDTO
    {
        public int ComicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Year { get; set; }
        public IComicImageDTO Image { get; set; }
        public int Pages { get; set; }
        public  int[] Authors { get; set; }
        public int[] Genres { get; set; }
    }
}
