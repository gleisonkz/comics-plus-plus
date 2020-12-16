using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Infra.EFRepository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.Infra.EFRepository.Repository
{
    public class EFCoreRepository<T> : IRepository<T> where T : class
    {
        private readonly ComicStoreDbContext context;
        private DbSet<T> dbSet;
        private DbSet<T> DbSet => dbSet ??= context.Set<T>();

        public EFCoreRepository(ComicStoreDbContext context)
        {
            this.context = context;
        }
        public T Add(T entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public T Update(T entity)
        {
            return DbSet.Update(entity).Entity;
        }

        public IQueryable<T> GetQuery(bool trackingChanges = true)
        {
            return trackingChanges ? DbSet : DbSet.AsNoTracking();

        }

        public async Task<T> FindAsync(params object[] id)
        {
            return await DbSet.FindAsync(id);
        }

        public T Attach(T entity)
        {
            return DbSet.Attach(entity).Entity;
        }

        public void Detach(T entity)
        {
            this.context.Entry(entity).State = EntityState.Detached;
        }


    }
}
