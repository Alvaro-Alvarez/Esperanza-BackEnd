using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace Esperanza.Service.Business
{
    public class ReCaptcharService : IReCaptcharService
    {
        private readonly GoogleReCaptchar GoogleReCaptchar;

        public ReCaptcharService(IOptions<GoogleReCaptchar> options)
        {
            GoogleReCaptchar = options.Value;
        }

        public async Task<bool> Validate(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token)) return false;
                // TODO: Parametrizar estas url's
                string url = "https://www.google.com/recaptcha/api/";
                var client = new RestClient(url);
                var request = new RestRequest("siteverify", Method.Post);
                //string _domain = IPGlobalProperties.GetIPGlobalProperties().DomainName;
                // Json to post.
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("secret", GoogleReCaptchar.SecretKey);
                request.AddParameter("response", token);
                request.AddParameter("remoteip", "localhost");

                var response = await client.ExecuteAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ReCaptcharResponse reCaptcharResponse = JsonConvert.DeserializeObject<ReCaptcharResponse>(response.Content);
                    return reCaptcharResponse.success;
                }
                else return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
