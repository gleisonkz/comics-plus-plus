using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class ComicImage
    {
        public int ComicID { get; set; }
        public Comic Comic { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Base64 { get; set; }
    }
}
