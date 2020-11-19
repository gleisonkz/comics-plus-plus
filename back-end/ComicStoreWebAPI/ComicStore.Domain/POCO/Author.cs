using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Comic> Comic { get; set; }
    }
}
