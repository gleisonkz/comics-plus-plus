using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Interfaces;
using System.Collections.Generic;

namespace ComicStore.Service.Services
{
    public abstract class ServiceFacadeBase : IServiceFacadeBase
    {
        protected readonly List<ICommand> commands = new List<ICommand>();
        private readonly IUnityOfWork unityOfWork;
        protected readonly IFactoryRepository factoryRepository;

        public ServiceFacadeBase(IFactoryRepository factoryRepository, IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
            this.factoryRepository = factoryRepository;
        }
        public virtual int Commit()
        {
            return unityOfWork.Commit();
        }

        public virtual void Rollback()
        {
            unityOfWork.Rollback();
        }
    }
}
