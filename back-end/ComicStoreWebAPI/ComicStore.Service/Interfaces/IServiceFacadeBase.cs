using System.Threading.Tasks;

namespace ComicStore.Service.Interfaces
{
    public interface IServiceFacadeBase
    {
        int Commit();
        void Rollback();
        Task<T> FindAsync<T>(params object[] id) where T : class;
    }
}
