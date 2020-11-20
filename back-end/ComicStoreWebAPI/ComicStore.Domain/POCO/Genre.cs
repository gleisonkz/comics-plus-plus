using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Comic> Comics { get; set; }
    }
}
