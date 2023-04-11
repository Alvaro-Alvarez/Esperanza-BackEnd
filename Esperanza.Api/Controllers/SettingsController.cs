using Esperanza.Core.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly EsperanzaLocations EsperanzaLocations;

        public SettingsController(IOptions<EsperanzaLocations> esperanzaLocations)
        {
            EsperanzaLocations = esperanzaLocations.Value;
        }


        [HttpGet("GetEsperanzaLocations")]
        public async Task<ActionResult> GetEsperanzaLocations()
        {
            return Ok(EsperanzaLocations);
        }
    }
}
