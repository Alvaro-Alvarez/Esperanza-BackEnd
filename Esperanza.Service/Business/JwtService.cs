using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Esperanza.Service.Business
{
    public class JwtService : IJwtService
    {
        private readonly JWTOptions JwtBearerTokenSettings;

        public JwtService(IOptions<JWTOptions> JwtSettings)
        {
            JwtBearerTokenSettings = JwtSettings.Value;
        }

        public string GenerateSecurityToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtBearerTokenSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = JwtBearerTokenSettings.Issuer,
                Audience = JwtBearerTokenSettings.Audience,
                Subject = new ClaimsIdentity(new[]
                {
                    // TODO: Ingresar nombre y apellido del usuario o email
                    new Claim(ClaimTypes.Name, user.Guid.ToString()),
                    new Claim(ClaimTypes.Role, user.UserRole.Name),
                }),
                Expires = DateTime.UtcNow.AddSeconds(JwtBearerTokenSettings.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal ValidatingSecurityToken(string tokenStrg)
        {
            SecurityToken token = new JwtSecurityToken();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtBearerTokenSettings.SecretKey);
            var validationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = JwtBearerTokenSettings.Issuer,
                ValidAudience = JwtBearerTokenSettings.Audience,
                ValidateLifetime = false
            };
            return tokenHandler.ValidateToken(tokenStrg, validationParameters, out token);
        }
    }
}
