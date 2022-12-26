using Esperanza.Core.Interfaces.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProductController : ControllerBase
    {
        private readonly IUserProductService _userProductService;

        public UserProductController(
            IUserProductService userProductService)
        {
            _userProductService = userProductService;
        }

        [HttpPost]
        [Route("UpdatePriceByUser/{userGuid}")]
        public async Task<ActionResult<object>> UpdatePriceByUser(string userGuid)
        {
            await _userProductService.UpdatePrices(userGuid);
            return Ok();
        }
    }
}
