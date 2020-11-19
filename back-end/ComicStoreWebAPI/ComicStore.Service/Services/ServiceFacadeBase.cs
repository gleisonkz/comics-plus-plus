using ComicStore.Domain.Interfaces;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Interfaces;

namespace ComicStore.Service.Services
{
    public abstract class ServiceFacadeBase : IServiceFacadeBase
    {

        private readonly IUnityOfWork unityOfWork;
        private readonly IFactoryRepository factoryRepository;

        public ServiceFacadeBase(IFactoryRepository factoryRepository, IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
            this.factoryRepository = factoryRepository;
        }
        public int Commit()
        {
            return unityOfWork.Commit();
        }

        public void Rollback()
        {
            unityOfWork.Rollback();
        }
    }
}
