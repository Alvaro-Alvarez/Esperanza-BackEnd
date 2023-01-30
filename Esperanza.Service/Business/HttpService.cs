using Esperanza.Core.Interfaces.Business;
using Newtonsoft.Json;
using RestSharp;

namespace Esperanza.Service.Business
{
    public class HttpService : IHttpService
    {
        private string url;
        private string controller;
        private string content;
        private string resp;

        public async Task<T> Get<T>(string url, string controller) where T : new()
        {
            try
            {
                this.url = url;
                this.controller = controller;
                var client = new RestClient(url);
                var request = new RestRequest(controller, Method.Get);
                request.AddHeader("content-type", "application/json");
                RestResponse response = await client.ExecuteAsync(request);

                this.content = response.Content;
                this.resp = JsonConvert.SerializeObject(response);

                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception ex)
            {
                throw new Exception($"STACKK->: {ex.StackTrace} | MSGG->: {ex.Message} | VALUESSS->: url: {url}, controller: {controller}, content: {content}, resp: {resp}");
            }
        }
    }
}
