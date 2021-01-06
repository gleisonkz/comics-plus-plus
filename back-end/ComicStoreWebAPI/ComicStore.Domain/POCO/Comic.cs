using ComicStore.Shared.Class;
using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class Comic
    {
        private int pages;
        public int ComicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Year { get; set; }
        public int Pages
        {
            get => pages;

            set
            {
                if (value <= 0)
                    throw new CustomException("O valor não pode ser menor ou igual a 0");
                pages = value;
            }
        }
        public virtual ComicImage Image { get; set; }
        public virtual ComicInventory Inventory { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
