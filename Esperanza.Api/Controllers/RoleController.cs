using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService RoleService;

        public RoleController(
            IRoleService roleService)
        {
            RoleService = roleService;
        }

        [HttpGet("GetByGuid/{guid}")]
        public async Task<ActionResult> GetByGuid(string guid)
        {
            return Ok(await RoleService.GetById(guid));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserRole role)
        {
            await RoleService.Insert(role, User.Identity.Name);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserRole role)
        {
            await RoleService.Update(role, User.Identity.Name);
            return Ok();
        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult> Delete(string guid)
        {
            await RoleService.Delete(guid, User.Identity.Name);
            return Ok();
        }
    }
}
