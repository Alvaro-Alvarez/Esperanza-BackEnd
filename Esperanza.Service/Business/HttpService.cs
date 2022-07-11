using Esperanza.Core.Interfaces.Business;
using Newtonsoft.Json;
using RestSharp;

namespace Esperanza.Service.Business
{
    public class HttpService : IHttpService
    {
        public async Task<T> Get<T>(string url, string controller) where T : new()
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(controller, Method.Get);
                request.AddHeader("content-type", "application/json");
                RestResponse response = await client.ExecuteAsync(request);
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
