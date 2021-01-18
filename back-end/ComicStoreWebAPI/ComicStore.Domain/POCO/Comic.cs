using ComicStore.Domain.Helpers;
using System;
using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class Comic
    {
        private int pages;
        private int year;
        private decimal price;
        public int ComicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price
        {
            get => price;
            set => price = ValidationHelper.SetValidation(value)
                                           .LessThanZero()
                                           .EqualsZero()
                                           .Assign();
        }
        public int Year
        {
            get => year;
            set => year = ValidationHelper.SetValidation(value)
                                          .LessThanZero()
                                          .EqualsZero()
                                          .GreaterThanCurrentYear()
                                          .Assign();
        }

        public int Pages
        {
            get => pages;
            set => pages = ValidationHelper.SetValidation(value)
                                               .LessThanZero()
                                               .EqualsZero()
                                               .Assign();
        }

        public virtual ComicImage Image { get; set; }
        public virtual ComicInventory Inventory { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
