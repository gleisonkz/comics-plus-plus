using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Service.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComicStore.Service.Interfaces
{
    public interface IComicService : IServiceFacadeBase
    {
        Comic CreateComic(IComicDTO comicDTO);
        Comic DeleteComic(int comicID);
        IQueryable<Comic> GetComicByID(int comicID);
        IQueryable<Comic> GetComic();
        IQueryable<Author> GetAuthorsByComicID(int comicID);
        IQueryable<Genre> GetGenresByComicID(int comicID);
        Paginator<dynamic> GetPaginatedComics(IFilter<Comic> filter, Func<Comic, dynamic> projection);
        IQueryable<ComicImage> GetComicImageByComicID(int comicID);
    }
}
