using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.Application.DTO
{
    public class AuthorDTO : IAuthorDTO
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }

        public void AssignPoco(Author poco)
        {
            poco.AuthorID = AuthorID;
            poco.Name = Name;
        }
    }
}
