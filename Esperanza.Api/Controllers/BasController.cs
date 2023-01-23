using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasController : ControllerBase
    {
        [HttpGet("Client/{code}")]
        [Authorize]
        public async Task<ActionResult> GetClient(string code)
        {
            var client = new RestClient("http://apipedidostron.esperanzadistri.com.ar/WebApiED/api/");
            var request = new RestRequest($"clientes/{code}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("Product/{clientCode}/{productCode}/{condition}")]
        [Authorize]
        public async Task<ActionResult> GetProduct(string clientCode, string productCode, string condition)
        {
            var client = new RestClient("http://apipedidostron.esperanzadistri.com.ar/WebApiED/api/");
            var request = new RestRequest($"productos/{productCode}/{clientCode}/{condition}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }
    }
}
