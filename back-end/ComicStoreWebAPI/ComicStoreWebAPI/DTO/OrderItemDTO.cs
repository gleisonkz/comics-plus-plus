using ComicStore.Domain.Interfaces;

namespace ComicStore.Application.DTO
{
    public class OrderItemDTO : IOrderItemDTO
    {
        public int Quantity { get; set; }
        public int ComicID { get; set; }
    }
}



