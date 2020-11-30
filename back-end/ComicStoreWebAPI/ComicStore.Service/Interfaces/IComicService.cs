using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Service.Classes;
using System;
using System.Linq;

namespace ComicStore.Service.Interfaces
{
    public interface IComicService : IServiceFacadeBase
    {
        Comic CreateComic(IComicDTO comicDTO);
        IQueryable<Comic> GetComic();
        Paginator<IComicDTO> GetComics(IFilter<Comic> filter, Func<Comic, IComicDTO> projection);
    }
}
