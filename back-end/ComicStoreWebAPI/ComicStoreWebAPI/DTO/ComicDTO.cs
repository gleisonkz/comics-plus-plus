using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public static implicit operator ComicDTO(Comic comic)
        {
            if (comic == null)
            {
                throw new ArgumentNullException(nameof(comic));
            }

            return new ComicDTO
            {
                ComicID = comic.ComicID,
                Title = comic.Title,
                Description = comic.Description,
                Price = comic.Price,
                Year = comic.Year,
                Pages = comic.Pages,
                Image = new ComicImageInfo
                {
                    Name = comic.Image.Name,
                    Extension = comic.Image.Extension,
                    Base64 = comic.Image.Base64

                },
                Authors = comic.Authors.Select(d =>
                                    new KeyValueAuthor { AuthorID = d.AuthorID, Name = d.Name })
                                                           .ToList(),
                Genres = comic.Genres.Select(d =>
                                    new KeyValueGenre { GenreID = d.GenreID, Description = d.Description })
                                                         .ToList(),
            };
        }
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

    public class SaveComicDTO : ISaveComicDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public IComicImageDTO Image { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        public int[] Authors { get; set; }
        [Required]
        public int[] Genres { get; set; }
    }
}
