using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using System.Linq;

namespace ComicStore.Service.Interfaces
{
    public interface IGenreService : IServiceFacadeBase
    {
        Genre CreateGenre(IGenreDTO genreDTO);
        IQueryable<Genre> GetGenre();
    }
}
