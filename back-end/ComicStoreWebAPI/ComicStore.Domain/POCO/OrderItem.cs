namespace ComicStore.Domain.POCO
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int ComicID { get; set; }
        public int OrderID { get; set; }
        public virtual Comic Comic { get; set; }
        public virtual Order Order { get; set; }
    }
}
