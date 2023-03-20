using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(
            IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("GetTopFive")]
        public async Task<ActionResult> GetTopFive()
        {
            return Ok(await _productService.GetTopFive(User.Identity.Name, User.Identity.Name != null));
        }

        [HttpGet("GetByCode/{cod}")]
        public async Task<ActionResult> GetByCode(string cod)
        {
            return Ok(await _productService.GetById(cod, User.Identity.Name != null, User.Identity.Name));
        }

        [HttpPost("GetAllWithPagination")]
        public async Task<ActionResult> GetByGuid([FromBody] Filter filter)
        {
            return Ok(await _productService.GetAllPaginated(filter, User.Identity.Name, User.Identity.Name != null));
        }

        [HttpPost("GetAllByLaboratory")]
        public async Task<ActionResult> GetAllWithPagination(GetByLaboratory filter)
        {
            return Ok(await _productService.GetAllByLaboratory(filter, User.Identity.Name, User.Identity.Name != null));
        }

        [HttpPost("GetAllRecommended")]
        public async Task<ActionResult> GetAllRecommended(GetRecommended request)
        {
            return Ok(await _productService.GetAllRecommended(request, User.Identity.Name));
        }

        [HttpPost("GetByVademecumFilter")]
        public async Task<ActionResult> GetByVademecumFilter([FromBody]  VademecumFilter filter)
        {
            return Ok(await _productService.GetByVademecumFilter(filter, User.Identity.Name));
        }

        [HttpPost("GetImagesByCodes")]
        public async Task<ActionResult> GetImagesByCodes(GetRecommended request)
        {
            return Ok(await _productService.GetImagesByCodes(request));
        }
    }
}
