namespace ComicStore.Domain.Interfaces
{
    public interface ISaveComicDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Year { get; set; }
        public IComicImageDTO Image { get; set; }
        public int Pages { get; set; }
        public int[] Authors { get; set; }
        public int[] Genres { get; set; }
        //void AssignPoco(Comic poco);
    }
}
