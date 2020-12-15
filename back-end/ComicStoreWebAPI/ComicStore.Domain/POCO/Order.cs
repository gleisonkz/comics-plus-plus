using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class Order
    {
        public int OrderID { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
