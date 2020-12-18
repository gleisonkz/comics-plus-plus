using ComicStore.Domain.POCO;
using ComicStore.Infra.BaseRepository.Interfaces;
using ComicStore.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ComicStore.Service.Services
{
    public class OrderService : ServiceFacadeBase, IOrderService
    {

        private readonly IRepository<Order> repoOrder;
        private readonly IRepository<Comic> repoComic;
        public OrderService(IFactoryRepository factoryRepository, IUnityOfWork unityOfWork) : base(factoryRepository, unityOfWork)
        {
            repoOrder = factoryRepository.CreateRepository<Order>();
            repoComic = factoryRepository.CreateRepository<Comic>();
        }

        public Order CreateOrder(IOrderDTO orderDTO)
        {

            ICollection<OrderItem> orderItemsPOCO = orderDTO.OrderItems.Select(c => new OrderItem
            {
                ComicID = c.ComicID,
                Quantity = c.Quantity,
                UnitValue = repoComic.GetQuery()
                                     .Single(d => d.ComicID == c.ComicID).Price,
                TotalValue = repoComic.GetQuery()
                                     .Single(d => d.ComicID == c.ComicID).Price * c.Quantity
            }).ToList();


            var objOrder = new Order
            {
                PaymentMethodID = orderDTO.PaymentMethodID,
                Address = new Address
                {
                    Line1 = orderDTO.Line1,
                    Line2 = orderDTO.Line2,
                    Number = orderDTO.Number,
                    Neighborhood = orderDTO.Neighborhood,
                    City = orderDTO.City,
                    State = orderDTO.State,
                    PostalCode = orderDTO.PostalCode
                },
                OrderItems = orderItemsPOCO
            };

            repoOrder.Add(objOrder);
            return objOrder;
        }


    }
}
