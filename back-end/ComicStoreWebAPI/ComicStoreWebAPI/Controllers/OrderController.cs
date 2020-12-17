using ComicStore.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComicStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController() { }

        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrderDTO order)
        {
            var newOrder = order.CustomerID;
            return Ok();
        }
    }

    public class OrderDTO
    {
        public int CustomerID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int Number { get; set; }
        public PaymentMethod PaymentMethodID { get; set; }
        public OrderItemDTO[] OrderItems { get; set; }
    }

    public class OrderItemDTO
    {
        public int Quantity { get; set; }
        public int ComicID { get; set; }
    }
}



