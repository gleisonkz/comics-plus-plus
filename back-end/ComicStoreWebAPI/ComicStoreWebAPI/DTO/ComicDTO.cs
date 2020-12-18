using ComicStore.Domain.POCO;
using System;
using System.Collections.Generic;
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
        public ComicImageDTO Image { get; set; }
        public int Pages { get; set; }
        public List<KeyValueAuthorDTO> Authors { get; set; }
        public List<KeyValueGenreDTO> Genres { get; set; }

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
                Image = new ComicImageDTO
                {
                    Name = comic.Image.Name,
                    Extension = comic.Image.Extension,
                    Base64 = comic.Image.Base64

                },
                Authors = comic.Authors.Select(d =>
                                    new KeyValueAuthorDTO { AuthorID = d.AuthorID, Name = d.Name })
                                                           .ToList(),
                Genres = comic.Genres.Select(d =>
                                    new KeyValueGenreDTO { GenreID = d.GenreID, Description = d.Description })
                                                         .ToList(),
            };
        }
    }
}
