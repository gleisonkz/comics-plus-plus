using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using System.Linq;

namespace ComicStore.Service.Interfaces
{
    public interface IAuthorService : IServiceFacadeBase
    {
        Author CreateAuthor(IAuthorDTO authorDTO);
        IQueryable<Author> GetAuthor();
    }
}
