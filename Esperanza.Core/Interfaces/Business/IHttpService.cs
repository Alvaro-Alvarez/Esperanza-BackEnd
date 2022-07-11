
namespace Esperanza.Core.Interfaces.Business
{
    public interface IHttpService
    {
        Task<T> Get<T>(string url, string controller) where T : new();
    }
}
