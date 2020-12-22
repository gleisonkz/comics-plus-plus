using ComicStore.Application.DTO;
using ComicStore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ComicStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public IActionResult PostOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                var order = orderService.CreateOrder(orderDTO);
                orderService.Commit();
                return Ok(new { orderID = order.OrderID });
            }
            catch (Exception ex)
            {
                orderService.Rollback();
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}



