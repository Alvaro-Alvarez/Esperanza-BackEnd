using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;

namespace Esperanza.Service.Business
{
    public class PrincipalImageService : IPrincipalImageService
    {
        private readonly IPrincipalImageRepository PrincipalImageRepository;

        public PrincipalImageService(IPrincipalImageRepository principalImageRepository)
        {
            PrincipalImageRepository = principalImageRepository;
        }

        public async Task Insert(PrincipalImage principalImage)
        {
            await PrincipalImageRepository.InsertAsync(principalImage);
        }
    }
}
