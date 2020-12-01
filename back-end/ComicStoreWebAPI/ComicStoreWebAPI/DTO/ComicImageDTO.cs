using ComicStore.Domain.Interfaces;

namespace ComicStore.Application.DTO
{

    public class ComicImageDTO : IComicImageDTO
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Base64 { get; set; }
    }
}
