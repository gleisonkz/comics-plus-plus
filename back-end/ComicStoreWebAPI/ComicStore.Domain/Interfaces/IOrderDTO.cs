using ComicStore.Domain.Enums;
using System.Collections.Generic;

namespace ComicStore.Domain.Interfaces
{
    public interface IOrderDTO
    {
        public int CustomerID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public PaymentMethod PaymentMethodID { get; set; }
        public ICollection<IOrderItemDTO> OrderItems { get; set; }
    }
}
