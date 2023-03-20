using Esperanza.Core.Models.Options;
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
        private readonly VademecumFilterOptions VademecumFilterOptions;

        public BasController(
            IOptions<BASApiOptions> options,
            IOptions<ServicesOption> servicesOption,
            IOptions<VademecumFilterOptions> vademecumFilterOptions
            )
        {
            BASApiOptions = options.Value;
            _servicesOption = servicesOption.Value;
            VademecumFilterOptions = vademecumFilterOptions.Value;
        }

        [HttpGet("Client/{code}")]
        public async Task<ActionResult> GetClient(string code)
        {
            var client = new RestClient(BASApiOptions.ApiUrl);
            var request = new RestRequest($"clientes/{code}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("Product/{clientCode}/{productCode}/{condition}")]
        public async Task<ActionResult> GetProduct(string clientCode, string productCode, string condition)
        {
            var client = new RestClient(BASApiOptions.ApiUrl);
            var request = new RestRequest($"productos/{productCode}/{clientCode}/{condition}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetSemaphoreData/{productCode}")]
        public async Task<ActionResult> GetSemaphoreData(string productCode)
        {
            var client = new RestClient(_servicesOption.Url);
            var request = new RestRequest($"{_servicesOption.SemaphoreController}{productCode}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetCarriers")]
        public async Task<ActionResult> GetCarriers()
        {
            var client = new RestClient(BASApiOptions.ApiUrl);
            var request = new RestRequest($"{BASApiOptions.CarriersController}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetDocumentosCtacte/{basCode}")]
        public async Task<ActionResult> GetDocumentosCtacte(string basCode)
        {
            var client = new RestClient(BASApiOptions.ApiUrl);
            var request = new RestRequest($"{BASApiOptions.DocumentosCtacteController}/{basCode}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetRecommendedProducts/{clientCode}")]
        public async Task<ActionResult> GetRecommendedProducts(string clientCode)
        {
            var client = new RestClient(_servicesOption.Url);
            var request = new RestRequest($"{_servicesOption.RecommendedController}{clientCode}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetEstadoPedidos/{clientCode}")]
        public async Task<ActionResult> GetEstadoPedidos(string clientCode)
        {
            var client = new RestClient(_servicesOption.Url);
            var request = new RestRequest($"{_servicesOption.EstadoPedidosController}{clientCode}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetPromociones/{clientCode}/{condition}")]
        public async Task<ActionResult> GetPromociones(string clientCode, string condition)
        {
            string controller = BASApiOptions.PromotionsController.Replace("{{clientId}}", clientCode).Replace("{{condition}}", condition);
            var client = new RestClient(BASApiOptions.ApiUrl);
            var request = new RestRequest(controller, Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetVademecumAcciones")]
        public async Task<ActionResult> GetVademecumAcciones()
        {
            var client = new RestClient(VademecumFilterOptions.Url);
            var request = new RestRequest($"{VademecumFilterOptions.AccionController}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetVademecumEspecies")]
        public async Task<ActionResult> GetVademecumEspecies()
        {
            var client = new RestClient(VademecumFilterOptions.Url);
            var request = new RestRequest($"{VademecumFilterOptions.EspecieController}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetVademecumAdministraciones")]
        public async Task<ActionResult> GetVademecumAdministraciones()
        {
            var client = new RestClient(VademecumFilterOptions.Url);
            var request = new RestRequest($"{VademecumFilterOptions.AdministracionController}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }

        [HttpGet("GetVademecumDrogras")]
        public async Task<ActionResult> GetVademecumDrogras()
        {
            var client = new RestClient(VademecumFilterOptions.Url);
            var request = new RestRequest($"{VademecumFilterOptions.DrograsController}", Method.Get);
            var res = await client.ExecuteAsync(request);
            return Ok(res.Content);
        }
    }
}
