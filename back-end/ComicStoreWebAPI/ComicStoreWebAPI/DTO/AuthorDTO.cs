using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;
using System;
using System.ComponentModel.DataAnnotations;

namespace ComicStore.Application.DTO
{
    public class AuthorDTO : IAuthorDTO
    {
        public int AuthorID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Nationality { get; set; }

        public void AssignPoco(Author poco)
        {
            poco.AuthorID = AuthorID;
            poco.Name = Name;
            poco.BirthDate = BirthDate;
            poco.Nationality = Nationality;
        }
    }
}
