
namespace Esperanza.Core.Models
{
    public class AccessToken
    {
        public AccessToken(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
