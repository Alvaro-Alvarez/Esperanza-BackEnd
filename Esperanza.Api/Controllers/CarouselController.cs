using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselController : ControllerBase
    {
        private readonly ICarouselService CarouselService;

        public CarouselController(
            ICarouselService carouselService
            )
        {
            CarouselService = carouselService;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await CarouselService.GetAll());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            return Ok(await CarouselService.GetById(id));
        }

        [HttpGet("GetByPageType/{pageType}")]
        public async Task<ActionResult> GetByPageType(string pageType)
        {
            return Ok(await CarouselService.GetByPageType(pageType));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CarouselPage page)
        {
            await CarouselService.Insert(page, User.Identity.Name);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Put([FromBody] CarouselPage page)
        {
            await CarouselService.Update(page, User.Identity.Name);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {
            await CarouselService.Delete(id, User.Identity.Name);
            return Ok();
        }
    }
}
