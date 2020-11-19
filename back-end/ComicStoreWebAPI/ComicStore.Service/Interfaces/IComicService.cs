using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;

namespace ComicStore.Service.Interfaces
{
    public interface IComicService : IServiceFacade
    {
        int GetComics();
        Comic CreateComic(IComicDTO comicDTO);
    }
}
