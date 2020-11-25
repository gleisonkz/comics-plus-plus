using ComicStore.Domain.POCO;

namespace ComicStore.Domain.Interfaces
{
    public interface IGenreDTO
    {
        public int GenreID { get; set; }
        public string Description { get; set; }
        void AssignPoco(Genre poco);
    }
}
