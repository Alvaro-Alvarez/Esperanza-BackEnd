using Esperanza.Core.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly IMasterDataService MasterDataService;

        public MasterDataController(
            IMasterDataService masterDataService)
        {
            MasterDataService = masterDataService;
        }

        [HttpGet]
        [Route("GetAllTypesOfDocuments")]
        public async Task<ActionResult> GetAllTypesOfDocuments()
        {
            return Ok(await MasterDataService.GetAllTypesOfDocumentsAsync());
        }

        [HttpGet]
        [Route("GetAllSexs")]
        public async Task<ActionResult> GetAllSexs()
        {
            return Ok(await MasterDataService.GetAllSexsAsync());
        }

        [HttpGet]
        [Route("GetAllUserRoles")]
        public async Task<ActionResult> GetAllUserRoles()
        {
            return Ok(await MasterDataService.GetAllUserRolesAsync());
        }

        [HttpGet]
        [Route("GetPagesTypes")]
        public async Task<ActionResult> GetPagesTypes()
        {
            return Ok(await MasterDataService.GetPagesTypes());
        }

        [HttpGet]
        [Route("GetConditionTypes")]
        public async Task<ActionResult> GetConditionTypes()
        {
            return Ok(await MasterDataService.GetConditionTypes());
        }

        [HttpGet]
        [Route("TestApi")]
        public async Task<ActionResult> TestApi()
        {
            return Ok(new List<string>() { "API", "Funcionando", "Correctamente" });
        }
    }
}
