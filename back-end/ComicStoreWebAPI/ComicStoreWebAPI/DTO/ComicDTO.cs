using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComicStore.Application.DTO
{

    public class ComicDTO
    {
        public int ComicID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public ComicImageInfo Image { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        public List<KeyValueAuthor> Authors { get; set; }
        [Required]
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
    }
}
