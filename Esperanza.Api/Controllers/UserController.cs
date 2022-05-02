using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
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
        public async Task<ActionResult> GetAll()
        {
            return Ok(await UserService.GetAllAsync());
        }

        [HttpGet]
        [Route("GetByGuid")]
        public async Task<ActionResult> GetByGuid()
        {
            return Ok(await UserService.GetByGuidAsync(User.Identity.Name));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AppUser user)
        {
            await UserService.InsertAsync(user, User.Identity.Name);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AppUser user)
        {
            await UserService.UpdateAsync(user, User.Identity.Name);
            return Ok();
        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult> Delete(string guid)
        {
            await UserService.DeleteAsync(guid, User.Identity.Name);
            return Ok();
        }
    }
}
