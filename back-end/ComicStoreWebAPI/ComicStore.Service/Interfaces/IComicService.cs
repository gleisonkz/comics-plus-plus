using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Service.Classes;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ComicStore.Service.Interfaces
{
    public interface IComicService : IServiceFacadeBase
    {
        Comic CreateComic(IComicDTO comicDTO);
        Comic DeleteComic(int comicID);
        Comic UpdateComic(IComicDTO comicDTO,int comicID);
        ComicInventory UpdateComicInventory(int comicID,int quantity);
        IQueryable<Comic> GetComicByID(int comicID);
        IQueryable<Comic> GetComic();
        IQueryable<ComicInventory> GetComicsInventory();
        IQueryable<Author> GetAuthorsByComicID(int comicID);        
        IQueryable<Genre> GetGenresByComicID(int comicID);
        Paginator<dynamic> GetPaginatedComics(IFilter<Comic> filter, Expression<Func<Comic, dynamic>> projection);
        Paginator<dynamic> GetPaginatedComicsInventory(IFilter<ComicInventory> filter, Expression<Func<ComicInventory, dynamic>> projection);
        IQueryable<ComicImage> GetComicImageByComicID(int comicID);
    }
}
