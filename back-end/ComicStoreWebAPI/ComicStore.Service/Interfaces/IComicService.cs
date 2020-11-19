using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using System.Linq;

namespace ComicStore.Service.Interfaces
{
    public interface IComicService : IServiceFacadeBase
    {
        Comic CreateGenre(IComicDTO comicDTO);
        IQueryable<Comic> GetGenre();
    }
}
