
namespace Esperanza.Core.Interfaces.Business
{
    public interface IReCaptcharService
    {
        Task<bool> Validate(string token);
    }
}
