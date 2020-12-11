using System.Collections.Generic;

namespace ComicStore.Domain.POCO
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Comic> Comics { get; set; }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public int UserID { get; set; }
    }

    

    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int ComicID { get; set; }
        public Comic Comic { get; set; }
    }
}
