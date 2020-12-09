namespace ComicStore.Domain.Interfaces
{
    public interface IComicImageDTO
    {
        string Name { get; set; }
        string Extension { get; set; }
        byte[] Base64 { get; set; }
    }
}
