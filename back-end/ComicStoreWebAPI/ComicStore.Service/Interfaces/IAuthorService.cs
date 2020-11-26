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
        Paginator<IAuthorDTO> GetAuthors(IFilter<Author> filter, System.Func<Author, IAuthorDTO> projection);
    }
}
