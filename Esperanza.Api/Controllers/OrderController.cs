using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService OrderService;

        public OrderController(IOrderService orderService)
        {
            OrderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> FinishOrder([FromBody] OrderItems orderItems)
        {
            await OrderService.FinishOrder(orderItems, User.Identity.Name);
            return Ok();
        }
    }
}
