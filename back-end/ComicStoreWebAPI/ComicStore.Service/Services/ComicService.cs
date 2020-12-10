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

            var image = new ComicImage
            {
                Base64 = comicDTO.Image.Base64,
                Extension = comicDTO.Image.Extension,
                Name = comicDTO.Image.Name
            };

            var stockItem = new ComicInventory
            {
                Quantity = 0
            };

            Comic comic = new Comic
            {
                Description = comicDTO.Description,
                Pages = comicDTO.Pages,
                Title = comicDTO.Title,
                Price = comicDTO.Price,
                Year = comicDTO.Year,
                Image = image,
                Inventory = stockItem,
                Genres = genres,
                Authors = authors
            };

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

        public IQueryable<ComicInventory> GetComicsInventory()
        {
            var repoInventory = factoryRepository.CreateRepository<ComicInventory>();
            return repoInventory.GetQuery();
        }

        public IQueryable<ComicImage> GetComicImageByComicID(int comicID)
        {
            var repoImage = factoryRepository.CreateRepository<ComicImage>();
            IQueryable<ComicImage> image = repoImage.GetQuery()
                                                    .Where(c => c.ComicID == comicID);
            return image;
        }

        public Paginator<dynamic> GetPaginatedComics(IFilter<Comic> filter, Expression<Func<Comic, dynamic>> projection)
        {
            Expression<Func<Comic, bool>> predicate = filter.GetPredicate();

            return Paginator<dynamic>
                .Paginate(repoComic.GetQuery()
                                   .Where(predicate)
                                   .OrderBy(c => c.ComicID), filter, projection);
        }

        public Paginator<dynamic> GetPaginatedComicsInventory(IFilter<ComicInventory> filter, Expression<Func<ComicInventory, dynamic>> projection)
        {
            var repoComicInventory = factoryRepository.CreateRepository<ComicInventory>();

            Expression<Func<ComicInventory, bool>> predicate = filter.GetPredicate();

            return Paginator<dynamic>
                .Paginate(repoComicInventory.GetQuery()
                                            .Where(predicate)
                                            .OrderBy(c => c.ComicID), filter, projection);
        }

        public IQueryable<Genre> GetGenresByComicID(int comicID)
        {
            return GetComic().Where(c => c.ComicID == comicID)
                             .SelectMany(c => c.Genres);
        }

        public Comic DeleteComic(int comicID)
        {
            Comic objComic = repoComic.GetQuery()
                                      .Where(c => c.ComicID == comicID)
                                      .SingleOrDefault();
            repoComic.Delete(objComic);
            return objComic;
        }

        public Comic UpdateComic(IComicDTO comicDTO, int comicID)
        {
            var repoAuthor = factoryRepository.CreateRepository<Author>();
            var repoGenre = factoryRepository.CreateRepository<Genre>();
            var repoImage = factoryRepository.CreateRepository<ComicImage>();

            Comic objComic = repoComic.GetQuery(false)
                                      .Where(c => c.ComicID == comicID)
                                      .SingleOrDefault();

            var authors = repoAuthor.GetQuery()
                                    .Where(author => comicDTO.Authors.Contains(author.AuthorID))
                                    .ToList();

            var genres = repoGenre.GetQuery()
                                  .Where(genre => comicDTO.Genres.Contains(genre.GenreID))
                                  .ToList();

            var image = repoImage.GetQuery()
                                 .Where(image => image.ComicID == comicID)
                                 .SingleOrDefault();

            image.Base64 = comicDTO.Image.Base64;
            image.Extension = comicDTO.Image.Extension;
            image.Name = comicDTO.Image.Name;



            objComic.Title = comicDTO.Title;
            objComic.Description = comicDTO.Description;
            objComic.Pages = comicDTO.Pages;
            objComic.Price = comicDTO.Price;
            objComic.Year = comicDTO.Year;
            objComic.Authors = authors;
            objComic.Genres = genres;
            objComic.Image = image;

            repoComic.Attach(objComic);
            repoComic.Update(objComic);

            return objComic;
        }

        public ComicInventory UpdateComicInventory(int comicID, int quantity)
        {
            var repoComicInventory = factoryRepository.CreateRepository<ComicInventory>();
            ComicInventory comicInventory = repoComicInventory.GetQuery()
                                                              .SingleOrDefault(c => c.ComicID == comicID);

            comicInventory.Quantity = quantity;
            return comicInventory;
        }

        public IQueryable<Comic> GetComicByID(int comicID)
        {
            //Comic objComic = repoComic.GetQuery()
            //                          .Where(c => c.ComicID == comicID)
            //                          .SingleOrDefault();

            IQueryable<Comic> objComic = repoComic.GetQuery()
                                                   .Where(c => c.ComicID == comicID);


            //objComic.Authors.Where(c => c.AuthorID == comicID).ToList();
            //objComic.Genres.Where(c => c.GenreID == comicID).ToList();



            return objComic;
        }


    }
}
