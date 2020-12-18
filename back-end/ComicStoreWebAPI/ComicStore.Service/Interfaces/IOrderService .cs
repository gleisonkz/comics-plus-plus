using ComicStore.Domain.Interfaces;
using ComicStore.Domain.POCO;

namespace ComicStore.Service.Interfaces
{
    public interface IOrderService : IServiceFacadeBase
    {
        Order CreateOrder(IOrderDTO orderDTO);
    }



}
