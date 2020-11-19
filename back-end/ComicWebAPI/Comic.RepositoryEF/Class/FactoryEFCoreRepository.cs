using Comic.Business.Interfaces;
using Comic.Repository.Interfaces;

namespace Comic.RepositoryEF.Class
{
    public class FactoryEFCoreRepository : IFactoryRepository
    {
        private readonly ComicContext context;

        public FactoryEFCoreRepository(ComicContext context)
        {
            this.context = context;
        }
        public IRepository<T> CreateRepository<T>() where T : class
        {
            return new EFCoreRepository<T>(context);
        }
    }
}
