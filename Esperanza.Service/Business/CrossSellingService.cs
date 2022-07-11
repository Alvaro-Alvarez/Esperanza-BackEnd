using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;

namespace Esperanza.Service.Business
{
    public class CrossSellingService : ICrossSellingService
    {
        private readonly ICrossSellingRepository CrossSellingRepository;

        public CrossSellingService(
            ICrossSellingRepository crossSellingRepository)
        {
            CrossSellingRepository = crossSellingRepository;
        }

        public async Task Insert(CrossSelling crossSelling)
        {
            await CrossSellingRepository.InsertAsync(crossSelling);
        }
    }
}
