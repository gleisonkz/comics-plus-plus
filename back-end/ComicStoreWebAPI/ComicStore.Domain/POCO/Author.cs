using ComicStore.Shared.Class;
using System;
using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class Author
    {
        public Author()
        {

        }
        private DateTime birthDate;
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate
        {
            get => birthDate;

            set
            {
                if (value > DateTime.UtcNow)
                    throw new GreaterThanCurrentDateException();

                birthDate = value;
            }
        }
        public string Nationality { get; set; }
        public virtual ICollection<Comic> Comics { get; set; }
    }
}
