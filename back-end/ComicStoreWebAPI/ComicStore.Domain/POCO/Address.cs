using ComicStore.Domain.Helpers;

namespace ComicStore.Domain.POCO
{
    public class Address
    {
        public string Line1 { get; set; }
        private int number;

        public int Number
        {
            get => number; 
            set => number = value;
        }

        public string Line2 { get; set; }
        public string State { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
