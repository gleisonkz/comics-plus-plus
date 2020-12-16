using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.Infra.BaseRepository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetQuery(bool trackingChanges = true);
        T Attach(T entity);
        Task<T> FindAsync(params object[] id);
        void Detach(T entity);
    }
}
