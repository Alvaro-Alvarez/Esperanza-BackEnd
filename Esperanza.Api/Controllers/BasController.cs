using Esperanza.Core.Models.Options;
using Esperanza.Core.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasController : ControllerBase
    {
        private readonly BASApiOptions BASApiOptions;
        private readonly ServicesOption _servicesOption;

        public BasController(IOptions<BASApiOptions> options, IOptions<ServicesOption> servicesOption)
        {
            BASApiOptions = options.Value;
            _servicesOption = servicesOption.Value;
        }

        [HttpGet("Client/{code}")]
        //[Authorize]
        public async Task<ActionResult> GetClient(string code)
        {
            var client = new RestClient(BASApiOptions.ApiUrl);
            var request = new RestRequest($"clientes/{code}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("Product/{clientCode}/{productCode}/{condition}")]
        //[Authorize]
        public async Task<ActionResult> GetProduct(string clientCode, string productCode, string condition)
        {
            var client = new RestClient(BASApiOptions.ApiUrl);
            var request = new RestRequest($"productos/{productCode}/{clientCode}/{condition}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetSemaphoreData/{productCode}")]
        //[Authorize]
        public async Task<ActionResult> GetSemaphoreData(string productCode)
        {
            var client = new RestClient(_servicesOption.Url);
            var request = new RestRequest($"{_servicesOption.SemaphoreController}{productCode}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetCarriers")]
        //[Authorize]
        public async Task<ActionResult> GetCarriers()
        {
            var client = new RestClient(BASApiOptions.ApiUrl);
            var request = new RestRequest($"{BASApiOptions.CarriersController}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        //[HttpPost("GetRangeSemaphoreData/{productCode}")]
        ////[Authorize]
        //public async Task<ActionResult> GetRangeSemaphoreData(BasSemaphoreRequest req) 
        //{
        //    var client = new RestClient(_servicesOption.Url);
        //    var request = new RestRequest($"{_servicesOption.SemaphoreController}{productCode}", Method.Get);
        //    var res = await client.ExecuteAsync(request);
        //    return Ok(res.Content);
        //}
    }
}
