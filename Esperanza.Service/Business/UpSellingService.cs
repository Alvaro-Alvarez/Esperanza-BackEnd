using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;

namespace Esperanza.Service.Business
{
    public class UpSellingService : IUpSellingService
    {
        private readonly IUpSellingRepository UpSellingRepository;

        public UpSellingService(
            IUpSellingRepository upSellingRepository)
        {
            UpSellingRepository = upSellingRepository;
        }

        public async Task Insert(UpSelling upSelling)
        {
            await UpSellingRepository.InsertAsync(upSelling);
        }
    }
}
