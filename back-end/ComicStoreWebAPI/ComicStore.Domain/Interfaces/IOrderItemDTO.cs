namespace ComicStore.Domain.Interfaces
{
    public interface IOrderItemDTO
    {
        public int Quantity { get; set; }
        public int ComicID { get; set; }
    }
}
