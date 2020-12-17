using ComicStore.Domain.Enums;
using ComicStore.Domain.POCO;

namespace ComicStore.Service.Interfaces
{
    public interface IOrderService : IServiceFacadeBase
    {
        Order CreateOrder(IOrderDTO orderDTO);
    }
    public interface IOrderDTO
    {
        public int CustomerID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int Number { get; set; }
        public PaymentMethod PaymentMethodID { get; set; }
        public IOrderItemDTO[] OrderItems { get; set; }
    }

    public interface IOrderItemDTO
    {
        public int Quantity { get; set; }
        public int ComicID { get; set; }
    }
}
