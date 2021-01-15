using ComicStore.Domain.Helpers;
using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class Comic
    {
        public int ComicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }

        private int pages;

        public int Pages
        {
            get => pages;
            set => pages = value;
        }

        public virtual ComicImage Image { get; set; }
        public virtual ComicInventory Inventory { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
