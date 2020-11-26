using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using ComicStore.Service.Interfaces;

namespace ComicStore.Service.Classes
{
    public class AssignAuthorCommand : ICommand
    {
        private readonly Author author;
        private readonly IAuthorDTO authorDTO;

        public AssignAuthorCommand(Author author, IAuthorDTO authorDTO)
        {
            this.author = author;
            this.authorDTO = authorDTO;
        }

        public void Execute()
        {
            authorDTO.AuthorID = author.AuthorID;
        }
    }
}
