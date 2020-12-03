using ComicStore.Domain.Interfaces;
using ComicStore.Service.Classes;
using ComicStore.Domain.POCO;
using System.Linq;

namespace ComicStore.Service.Interfaces
{
    public interface IGenreService : IServiceFacadeBase
    {
        Genre CreateGenre(IGenreDTO genreDTO);
        Genre UpdateGenre(IGenreDTO genreDTO);
        Genre DeleteGenre(int genreID);
        Genre DeleteGenreRelationships(int genreID);
        IQueryable<Genre> GetGenre();
        IQueryable<Genre> GetGenresByName(string description);
        Paginator<dynamic> GetPaginatedGenres(IFilter<Genre> filter, System.Func<Genre, dynamic> projection);
    }
}
