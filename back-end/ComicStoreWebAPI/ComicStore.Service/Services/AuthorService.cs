using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Interfaces;
using System.Linq;

namespace ComicStore.Service.Services
{
    public class AuthorService : ServiceFacadeBase, IAuthorService
    {
        private readonly IRepository<Author> repoAuthor;
        public AuthorService(IFactoryRepository factoryRepository, IUnityOfWork unityOfWork) : base(factoryRepository, unityOfWork)
        {
            repoAuthor = factoryRepository.CreateRepository<Author>();
        }

        public Author CreateAuthor(IAuthorDTO authorDTO)
        {
            var objAuthor = new Author
            {
                Name = authorDTO.Name
            };

            repoAuthor.Add(objAuthor);
            return objAuthor;
        }

        public IQueryable<Author> GetAuthor()
        {
            return repoAuthor.GetQuery();
        }
    }
}
