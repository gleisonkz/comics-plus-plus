using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Classes;
using ComicStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ComicStore.Service.Services
{
    public class ComicService : ServiceFacadeBase, IComicService
    {
        private readonly IRepository<Comic> repoComic;
        public ComicService(IFactoryRepository factoryRepository, IUnityOfWork unityOfWork) : base(factoryRepository, unityOfWork)
        {
            repoComic = factoryRepository.CreateRepository<Comic>();
        }

        public Comic CreateComic(IComicDTO comicDTO)
        {
            var repoAuthor = factoryRepository.CreateRepository<Author>();
            var repoGenre = factoryRepository.CreateRepository<Genre>();
            var repoImage = factoryRepository.CreateRepository<ComicImage>();

            List<Author> authors = repoAuthor.GetQuery()
                                             .Where(c => comicDTO.Authors.Contains(c.AuthorID))
                                             .ToList();

            List<Genre> genres = repoGenre.GetQuery()
                                          .Where(c => comicDTO.Genres.Contains(c.GenreID))
                                          .ToList();

            var image = new ComicImage
            {
                Base64 = comicDTO.Image.Base64,                
                Extension = comicDTO.Image.Extension,
                Name = comicDTO.Image.Name
            };

            Comic comic = new Comic
            {
                Description = comicDTO.Description,
                Pages = comicDTO.Pages,
                Title = comicDTO.Title,
                Price = comicDTO.Price,
                Year = comicDTO.Year,
                Image = image,
                Genres = genres,
                Authors = authors
            };            

            repoComic.Attach(comic);
            return repoComic.Add(comic);            
        }

        public IQueryable<Author> GetAuthorsByComicID(int comicID)
        {
            return GetComic().Where(c => c.ComicID == comicID)
                             .SelectMany(c => c.Authors);                          
        }

        public IQueryable<Comic> GetComic()
        {
            return repoComic.GetQuery();
        }

        public IQueryable<ComicImage> GetComicImageByComicID(int comicID)
        {
            var repoImage = factoryRepository.CreateRepository<ComicImage>();
            IQueryable<ComicImage> image = repoImage.GetQuery()
                                                    .Where(c => c.ComicID == comicID);                                   
            return image;
        }

        public Paginator<dynamic> GetComics(IFilter<Comic> filter, Func<Comic, dynamic> projection)
        {
            Expression<Func<Comic, bool>> predicate = filter.GetPredicate();

            return Paginator<dynamic>
                .Paginate(repoComic.GetQuery()
                                   .Where(predicate)
                                   .OrderBy(c => c.ComicID), filter, projection);
        }

        public IQueryable<Genre> GetGenresByComicID(int comicID)
        {
            return GetComic().Where(c => c.ComicID == comicID)
                             .SelectMany(c => c.Genres);                          
        }
    }
}
