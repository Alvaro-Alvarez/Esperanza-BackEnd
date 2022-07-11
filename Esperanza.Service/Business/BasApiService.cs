using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models.Options;
using Esperanza.Core.Models.Response;
using Microsoft.Extensions.Options;

namespace Esperanza.Service.Business
{
    public class BasApiService : IBasApiService
    {
        private readonly IHttpService _httpService;
        private readonly BASApiOptions _basApiSettings;

        public BasApiService(
            IOptions<BASApiOptions> basApiSettings,
            IHttpService httpService)
        {
            _httpService = httpService;
            _basApiSettings = basApiSettings.Value;
        }

        public async Task<bool> CustomerExists(string clientId)
        {
            string controller = _basApiSettings.ClientController.Replace(_basApiSettings.ParamExpClientId, clientId);
            var resp = await _httpService.Get<ClientResponse>(_basApiSettings.ApiUrl, controller);
            return resp != null;
        }
    }
}
