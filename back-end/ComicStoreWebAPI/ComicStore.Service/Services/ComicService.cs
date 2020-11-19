using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Interfaces;

namespace ComicStore.Service.Services
{
    public class ComicService : ServiceFacadeBase, IComicService
    {
        private readonly IRepository<Comic> repoComic;
        public ComicService(Interfaces.IFactoryRepository factoryRepository, IUnityOfWork unityOfWork) : base(factoryRepository, unityOfWork)
        {
        }

        public Comic CreateComic(IComicDTO comicDTO)
        {
            throw new System.NotImplementedException();
        }

        public int GetComics()
        {
            throw new System.NotImplementedException();
        }
    }
}
