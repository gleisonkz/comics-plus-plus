using Comic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comic.RepositoryEF.Class
{
    public class EFCoreRepository<T> : IRepository<T> where T : class
    {
        private readonly ComicContext context;
        private DbSet<T> dbSet;
        private DbSet<T> DbSet => dbSet ??= context.Set<T>();

        public EFCoreRepository(ComicContext context)
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
            return DbSet.AsNoTracking();
        }
    }
}
