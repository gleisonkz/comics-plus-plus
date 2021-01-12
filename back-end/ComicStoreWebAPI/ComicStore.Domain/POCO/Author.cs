using ComicStore.Shared.Class;
using System;
using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class Author
    {
        private DateTime birthDate;
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate
        {
            get => birthDate;

            set
            {
                if (value > DateTime.UtcNow)
                    throw new CustomException("A data não pode ser maior que a data atual");

                birthDate = value;
            }
        }
        public string Nationality { get; set; }
        public virtual ICollection<Comic> Comics { get; set; }
    }
}
