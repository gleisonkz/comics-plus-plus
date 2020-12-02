using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class Comic
    {
        public int ComicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public virtual ComicImage Image { get; set; }
        public virtual ICollection<Author> Authors { get; set; } 
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
