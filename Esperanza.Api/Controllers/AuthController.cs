using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService JwtService;
        private readonly IAuthService AuthService;

        public AuthController(IJwtService jwtService, IAuthService authService)
        {
            JwtService = jwtService;
            AuthService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] LoginCredentials credentials)
        {
            AccessToken accessToken = new AccessToken(JwtService.GenerateSecurityToken(await AuthService.ValidateUser(credentials)));
            return Ok(accessToken);
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPassword request)
        {
            await AuthService.ResetPassword(request);
            return Ok();
        }

        [HttpPost("ConfirmResetPassword")]
        public async Task<ActionResult> ConfirmResetPassword([FromBody] ConfirmResetPassword request)
        {
            await AuthService.ConfirmResetPassword(request);
            return Ok();
        }
    }
}
