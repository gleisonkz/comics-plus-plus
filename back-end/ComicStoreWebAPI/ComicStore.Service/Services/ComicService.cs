using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Interfaces;
using System.Linq;

namespace ComicStore.Service.Services
{
    public class ComicService : ServiceFacadeBase, IComicService
    {
        private readonly IRepository<Comic> repoComic;
        public ComicService(Interfaces.IFactoryRepository factoryRepository, IUnityOfWork unityOfWork, IRepository<Comic> repoComic) : base(factoryRepository, unityOfWork)
        {
            this.repoComic = repoComic;
        }

        public Comic CreateGenre(IComicDTO comicDTO)
        {
            Comic comic = new Comic
            {
                Description = comicDTO.Description,
                Pages = comicDTO.Pages,
                Title = comicDTO.Title,
                Price = comicDTO.Price,
                Year = comicDTO.Year,                                
            };

            repoComic.Add(comic);
            return comic;
        }

        public IQueryable<Comic> GetGenre()
        {
            return repoComic.GetQuery();
        }
    }
}
