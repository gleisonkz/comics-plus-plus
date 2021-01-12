using ComicStore.Domain.POCO;
using System;

namespace ComicStore.Domain.Interfaces
{
    public interface IAuthorDTO
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        void AssignPoco(Author poco);
    }
}
