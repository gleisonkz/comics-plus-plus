using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Classes;
using ComicStore.Service.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

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
            var objAuthor = new Author();
            authorDTO.AssignPoco(objAuthor);

            commands.Add(new AssignAuthorCommand(objAuthor, authorDTO));
            repoAuthor.Add(objAuthor);
            return objAuthor;
        }

        public Author UpdateAuthor(IAuthorDTO authorDTO)
        {            
            Author objAuthor = repoAuthor.GetQuery()
                                      .Where(c => c.AuthorID == authorDTO.AuthorID)
                                      .SingleOrDefault();
            authorDTO.AssignPoco(objAuthor);
            repoAuthor.Update(objAuthor);
            return objAuthor;
        }

        public Author DeleteAuthor(int authorID)
        {            
            Author objAuthor = repoAuthor.GetQuery()
                                      .Where(c => c.AuthorID == authorID)
                                      .SingleOrDefault();
            repoAuthor.Delete(objAuthor);
            return objAuthor;
        }

        public Paginator<dynamic> GetPaginatedAuthors(IFilter<Author> filter, Expression<Func<Author, dynamic>> projection)
        {
            Expression<Func<Author, bool>> predicate = filter.GetPredicate();

            return Paginator<dynamic>
                .Paginate(repoAuthor.GetQuery()
                                   .Where(predicate)
                                   .OrderBy(c => c.AuthorID), filter, projection);
        }

        public IQueryable<Author> GetAuthor()
        {
            return repoAuthor.GetQuery();
        }

        public IQueryable<Author> GetAuthorsByName(string name)
        {
            return repoAuthor.GetQuery()
                             .Where(c=> c.Name.Contains(name));
        }
    }
}
