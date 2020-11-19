
using Comic.Repository.Interfaces;

namespace Comic.Business.Interfaces
{
    public interface IFactoryRepository
    {
        IRepository<T> CreateRepository<T>() where T : class;
    }
}
