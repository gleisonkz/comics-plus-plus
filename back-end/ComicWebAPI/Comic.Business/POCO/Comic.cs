using System.Collections.Generic;

namespace Comic.Business.POCO
{
    public class Comic
    {
        public int ComicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public int AuthorID { get; set; }
        public float Price { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public ICollection<Author> Authors { get; set; }
    }

    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public ICollection<Comic> Comics { get; set; }
    }

    public class Genre
    {
        public int GenreID { get; set; }
        public string Description { get; set; }
    }
}
