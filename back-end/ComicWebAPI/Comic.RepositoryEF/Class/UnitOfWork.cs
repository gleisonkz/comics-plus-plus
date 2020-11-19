using Microsoft.EntityFrameworkCore;
using Proffy.Repository.Interfaces;

namespace Comic.RepositoryEF.Class
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ComicContext context;

        public UnityOfWork(ComicContext context)
        {
            this.context = context;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public void Rollback()
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
    }
}
