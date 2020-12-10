using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class ComicInventory
    {
        public int ComicID { get; set; }
        public int Quantity { get; set; }
        public virtual Comic Comic { get; set; }
    }
}
