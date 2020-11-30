using System.Linq;

namespace ComicStore.Infra.BaseRepository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);        
        IQueryable<T> GetQuery(bool trackingChanges = true);
        T Attach(T entity);
    }
}
