using ComicStore.Infra.BaseRepository.Interfaces;

namespace ComicStore.Service.Interfaces
{
    public interface IFactoryRepository
    {
        IRepository<T> CreateRepository<T>() where T : class;
    }
}
