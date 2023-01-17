using Esperanza.Core.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IItemUpdateService ItemUpdateService;

        public TestController(IItemUpdateService itemUpdateService)
        {
            ItemUpdateService = itemUpdateService;
        }

        [HttpGet]
        [Route("UpdateItems")]
        public async Task<ActionResult> UpdateItems()
        {
            try
            {
                await ItemUpdateService.UpdateProducts();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Mensaje -->: {e.Message} | StackTrece -->: {e.StackTrace}");
            }
        }

        [HttpGet]
        [Route("UpdateCustomers")]
        public async Task<ActionResult> UpdateCustomers()
        {
            try
            {
                await ItemUpdateService.UpdateCtaCte();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Mensaje -->: {e.Message} | StackTrece -->: {e.StackTrace}");
            }
        }

        [HttpGet]
        [Route("UpdateConditions")]
        public async Task<ActionResult> UpdateConditions()
        {
            try
            {
                await ItemUpdateService.UpdateConditions();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Mensaje -->: {e.Message} | StackTrece -->: {e.StackTrace}");
            }
        }

        [HttpGet]
        [Route("UpdatePriceList")]
        public async Task<ActionResult> UpdatePriceList()
        {
            try
            {
                await ItemUpdateService.UpdateLists();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Mensaje -->: {e.Message} | StackTrece -->: {e.StackTrace}");
            }
        }

        //[HttpGet]
        //[Route("UpdateTransport")]
        //public async Task<ActionResult> UpdateTransport()
        //{
        //    try
        //    {
        //        await ItemUpdateService.UpdateTranspors();
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest($"Mensaje -->: {e.Message} | StackTrece -->: {e.StackTrace}");
        //    }
        //}
    }
}
