using ComicStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.Application.DTO
{
    public class AuthorDTO : IAuthorDTO
    {
        public int AuthorID { get ; set ; }
        public string Name { get ; set ; }
    }
}
