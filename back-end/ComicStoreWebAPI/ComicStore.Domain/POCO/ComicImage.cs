namespace ComicStore.Domain.POCO
{
    public class ComicImage
    {
        public int ComicID { get; set; }
        public virtual Comic Comic { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Base64 { get; set; }
    }
}
