using Esperanza.Core.Models;
using System.Security.Claims;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IJwtService
    {
        string GenerateSecurityToken(AppUser user);
        ClaimsPrincipal ValidatingSecurityToken(string tokenStrg);
    }
}
