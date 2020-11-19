using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;

namespace ComicStore.Service.Interfaces
{
    public interface IComicService : IServiceFacadeBase
    {
        int GetComics();
        Comic CreateComic(IComicDTO comicDTO);
    }
}
