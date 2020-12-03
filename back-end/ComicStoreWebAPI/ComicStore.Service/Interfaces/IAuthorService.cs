using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Service.Classes;
using System.Linq;

namespace ComicStore.Service.Interfaces
{
    public interface IAuthorService : IServiceFacadeBase
    {
        Author CreateAuthor(IAuthorDTO authorDTO);
        Author UpdateAuthor(IAuthorDTO authorDTO);
        Author DeleteAuthor(int authorID);        
        IQueryable<Author> GetAuthor();
        IQueryable<Author> GetAuthorsByName(string name);
        Paginator<dynamic> GetPaginatedAuthors(IFilter<Author> filter, System.Func<Author, dynamic> projection);
    }
}
