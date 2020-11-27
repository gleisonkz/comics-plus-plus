using ComicStore.Domain.Interfaces;
using System.Drawing;

namespace ComicStore.Application.DTO
{
    public class ComicDTO : IComicDTO
    {
        public int ComicID { get ; set ; }
        public string Title { get ; set ; }
        public string Description { get ; set ; }
        public float Price { get ; set ; }
        public int Year { get ; set ; }
        public int Pages { get ; set ; }
        public Image Image { get; set; }
        public int[] Authors { get ; set ; }
        public int[] Genres { get ; set ; }
    }
}
