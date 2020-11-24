using System.Reflection.Metadata;
using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Interfaces;
using System.Linq;
using System.Collections.Generic;
using ComicStore.Service.Classes;

namespace ComicStore.Service.Services
{
    public class GenreService : ServiceFacadeBase, IGenreService
    {
        private readonly IRepository<Genre> repoGenre;
        public GenreService(IFactoryRepository factoryRepository, IUnityOfWork unityOfWork) : base(factoryRepository, unityOfWork)
        {
            repoGenre = factoryRepository.CreateRepository<Genre>();
        }

        public Genre CreateGenre(IGenreDTO genreDTO)
        {
            var objGenre = new Genre
            {
                Description = genreDTO.Description
            };

            repoGenre.Add(objGenre);
            return objGenre;
        }

        public IQueryable<Genre> GetGenre()
        {
            return repoGenre.GetQuery();
        }

        public Paginator<IGenreDTO> GetGenres(
            IFilter<Genre> genreFilter, System.Func<Genre, IGenreDTO> projection
            )
        {
            return Paginator<IGenreDTO>.Paginate(
                repoGenre.GetQuery().OrderBy(c => c.Description),
                genreFilter,
                projection
                );
        }
    }
}
