using Comic.Business.Interfaces;
using Proffy.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comic.Business.Services
{
    public abstract class ServiceFacadeBase : IServiceFacade
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
