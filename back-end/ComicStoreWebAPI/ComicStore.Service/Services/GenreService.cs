using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Interfaces;
using System.Linq;

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
    }
}
