using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAppUserService UserService;

        public UserController(
            IAppUserService userService
            )
        {
            UserService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await UserService.GetAllFull());
        }

        [HttpGet("GetByGuid/{guid}")]
        [Authorize]
        public async Task<ActionResult> GetByGuid(string guid)
        {
            return Ok(await UserService.GetByGuidAsync(guid));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AppUser user)
        {
            await UserService.InsertAsync(user, User.Identity.Name);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Put([FromBody] AppUser user)
        {
            await UserService.UpdateAsync(user, User.Identity.Name);
            return Ok();
        }

        [HttpDelete("{guid}")]
        [Authorize]
        public async Task<ActionResult> Delete(string guid)
        {
            await UserService.DeleteAsync(guid, User.Identity.Name);
            return Ok();
        }
    }
}
