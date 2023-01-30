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
    }
}
