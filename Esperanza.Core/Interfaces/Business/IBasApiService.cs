namespace Esperanza.Core.Interfaces.Business
{
    public interface IBasApiService
    {
        Task<bool> CustomerExists(string clientId);
    }
}
