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

            List<Author> authors = repoAuthor.GetQuery()
                                             .Where(c => comicDTO.Authors.Contains(c.AuthorID))
                                             .ToList();

            List<Genre> genres = repoGenre.GetQuery()
                                          .Where(c => comicDTO.Genres.Contains(c.GenreID))
                                          .ToList();

            Comic comic = new Comic
            {
                Description = comicDTO.Description,
                Pages = comicDTO.Pages,
                Title = comicDTO.Title,
                Price = comicDTO.Price,
                Year = comicDTO.Year,
                Image = comicDTO.Image,
            };

            repoComic.Attach(comic);

            comic.Genres = genres;
            comic.Authors = authors;

            repoComic.Add(comic);
            return comic;
        }

        public IQueryable<Comic> GetComic()
        {
            return repoComic.GetQuery();
        }

        public Paginator<IComicDTO> GetComics(IFilter<Comic> filter, Func<Comic, IComicDTO> projection)
        {
            Expression<Func<Comic, bool>> predicate = filter.GetPredicate();

            return Paginator<IComicDTO>
                .Paginate(repoComic.GetQuery()
                                   .Where(predicate)
                                   .OrderBy(c => c.ComicID), filter, projection);
        }
    }
}
