using ComicStore.Domain.POCO;

namespace ComicStore.Domain.Interfaces
{
    public interface IAuthorDTO
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        void AssignPoco(Author poco);
    }
}
