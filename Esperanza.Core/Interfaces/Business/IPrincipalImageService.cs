using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IPrincipalImageService
    {
        Task Insert(PrincipalImage principalImage);
    }
}
