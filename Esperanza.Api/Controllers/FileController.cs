using Esperanza.Core.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(
            IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("ProductsByXlsx")]
        public async Task<ActionResult> ProductsByXlsx(IFormFile file)
        {
            await _fileService.ImportProducts(file);
            return Ok();
        }
    }
}
