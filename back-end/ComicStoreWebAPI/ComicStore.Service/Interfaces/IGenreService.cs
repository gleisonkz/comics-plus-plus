using ComicStore.Domain.Interfaces;
using ComicStore.Service.Classes;
using ComicStore.Domain.POCO;
using System.Linq;

namespace ComicStore.Service.Interfaces
{
    public interface IGenreService : IServiceFacadeBase
    {
        Genre CreateGenre(IGenreDTO genreDTO);
        IQueryable<Genre> GetGenre();
        Paginator<IGenreDTO> GetGenres(IFilter<Genre> genreFilter, System.Func<Genre, IGenreDTO> projection);
    }
}
