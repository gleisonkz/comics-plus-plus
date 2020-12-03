using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using System.Collections.Generic;

namespace ComicStore.Application.DTO
{

    public class ComicDTO
    {
        public int ComicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Year { get; set; }
        public ComicImageInfo Image { get; set; }
        public int Pages { get; set; }
        public List<KeyValueAuthor> Authors { get; set; }
        public List<KeyValueGenre> Genres { get; set; }
    }

    public class ComicImageInfo
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Base64 { get; set; }
    }

    public class KeyValueAuthor
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
    }

    public class KeyValueGenre
    {
        public int GenreID { get; set; }
        public string Description { get; set; }
    }

    public class SaveComicDTO : IComicDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Year { get; set; }
        public IComicImageDTO Image { get; set; }
        public int Pages { get; set; }
        public int[] Authors { get; set; }
        public int[] Genres { get; set; }

        //public void AssignPoco(Comic poco, int comicID)
        //{
        //    poco.ComicID = comicID;
        //    poco.Title = Title;
        //    poco.Description = Description;
        //    poco.Price = Price;
        //    poco.Year = Year;
        //    poco.Pages = Pages;
        //    poco.Authors = Authors;

        //}
    }
}
