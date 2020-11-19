namespace ComicStore.Domain.Interfaces
{
    public interface IComicDTO
    {
        public int ComicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int GenreID { get; set; }        
        public int AuthorID { get; set; }
        public float Price { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }        
    }
}
