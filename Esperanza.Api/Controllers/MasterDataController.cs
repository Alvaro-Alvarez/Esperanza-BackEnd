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
        [Route("GetAllCountries")]
        public async Task<ActionResult> GetAllCountries()
        {
            return Ok(await MasterDataService.GetAllCountriesAsync());
        }

        [HttpGet]
        [Route("GetAllCities")]
        public async Task<ActionResult> GetAllCities()
        {
            return Ok(await MasterDataService.GetAllCitiesAsync());
        }

        [HttpGet]
        [Route("GetAllNeighborhoods")]
        public async Task<ActionResult> GetAllNeighborhoods()
        {
            return Ok(await MasterDataService.GetAllNeighborhoodsAsync());
        }

        [HttpGet]
        [Route("GetAllUserRoles")]
        public async Task<ActionResult> GetAllUserRoles()
        {
            return Ok(await MasterDataService.GetAllUserRolesAsync());
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<ActionResult> GetAllCategories()
        {
            return Ok(await MasterDataService.GetAllCategoriesAsync());
        }

        [HttpGet]
        [Route("GetAllKinds")]
        public async Task<ActionResult> GetAllKinds()
        {
            return Ok(await MasterDataService.GetAllKindsAsync());
        }

        [HttpGet]
        [Route("GetAllLines")]
        public async Task<ActionResult> GetAllLines()
        {
            return Ok(await MasterDataService.GetAllLinesAsync());
        }

        [HttpGet]
        [Route("GetAllOrderStatues")]
        public async Task<ActionResult> GetAllOrderStatues()
        {
            return Ok(await MasterDataService.GetAllOrderStatuesAsync());
        }
    }
}
