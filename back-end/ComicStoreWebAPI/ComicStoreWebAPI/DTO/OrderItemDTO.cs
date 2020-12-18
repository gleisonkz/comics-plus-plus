using ComicStore.Service.Interfaces;

namespace ComicStore.Application.DTO
{
    public class OrderItemDTO : IOrderItemDTO
    {
        public int Quantity { get; set; }
        public int ComicID { get; set; }
    }
}



