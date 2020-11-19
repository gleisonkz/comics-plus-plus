using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class Comic
    {
        public int ComicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }        
        public float Price { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public virtual ICollection<Author> Author { get; set; }
    }
}
