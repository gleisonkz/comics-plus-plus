using System.ComponentModel.DataAnnotations;
using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;

namespace ComicStore.Application.DTO
{
    public class GenreDTO : IGenreDTO
    {
        public int GenreID { get; set; }
        [Required]
        public string Description { get; set; }

        public void AssignPoco(Genre poco)
        {
            poco.GenreID = GenreID;
            poco.Description = Description;
        }
    }
}
