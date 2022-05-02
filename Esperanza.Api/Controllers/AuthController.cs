using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
