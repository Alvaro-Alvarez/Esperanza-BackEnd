using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _productService.GetAllFull());
        }

        [HttpGet("GetByCode/{cod}")]
        public async Task<ActionResult> GetByCode(string cod)
        {
            return Ok(await _productService.GetById(cod, User.Identity.Name != null));
        }

        [HttpPost("GetAllWithPagination")]
        public async Task<ActionResult> GetByGuid([FromBody] Pagination pagination)
        {
            return Ok(await _productService.GetAllPaginated(pagination, User.Identity.Name, User.Identity.Name != null));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            return Ok(await _productService.InsertProduct(product, User.Identity.Name));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Product product)
        {
            return Ok(await _productService.UpdateProduct(product, User.Identity.Name));
        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult> Delete(string guid)
        {
            await _productService.DeleteProduct(guid, User.Identity.Name);
            return Ok();
        }
    }
}
