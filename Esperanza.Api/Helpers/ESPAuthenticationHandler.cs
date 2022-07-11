using Esperanza.Core.Interfaces.Business;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace Esperanza.Api.Helpers
{
    public class ESPAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IJwtService _jwtService;

        public ESPAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IJwtService jwtService)
            : base(options, logger, encoder, clock)
        {
            _jwtService = jwtService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("esp-token"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            try
            {
                string token = Request.Headers["esp-token"].ToString();
                var principal = _jwtService.ValidatingSecurityToken(token);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return await Task.Run(() => AuthenticateResult.Success(ticket));
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }
        }
    }
}
