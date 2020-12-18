using ComicStore.Domain.Enums;
using ComicStore.Domain.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComicStore.Application.DTO
{
    public class OrderDTO : IOrderDTO
    {
        public int CustomerID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int Number { get; set; }
        public PaymentMethod PaymentMethodID { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        [JsonConverter(typeof(CustomJsonConverter<IOrderItemDTO, OrderItemDTO>))]
        public ICollection<IOrderItemDTO> OrderItems { get; set; }
    }
}



