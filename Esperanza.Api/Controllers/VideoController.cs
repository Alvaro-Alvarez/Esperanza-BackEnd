using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Esperanza.Service.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IPromotionalVideoService PromotionalVideoService;

        public VideoController(
            IPromotionalVideoService promotionalVideoService
            )
        {
            PromotionalVideoService = promotionalVideoService;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await PromotionalVideoService.GetAll());
        }

        [HttpGet("GetTopFive")]
        public async Task<ActionResult> GetTopFive()
        {
            return Ok(await PromotionalVideoService.GetTopFive());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            return Ok(await PromotionalVideoService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PromotionalVideo promotionalVideo)
        {
            await PromotionalVideoService.Insert(promotionalVideo, User.Identity.Name);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Put([FromBody] PromotionalVideo promotionalVideo)
        {
            await PromotionalVideoService.Update(promotionalVideo, User.Identity.Name);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {
            await PromotionalVideoService.Delete(id, User.Identity.Name);
            return Ok();
        }
    }
}
