using Esperanza.Core.Models.Sync;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface ICustomerConditionSyncRepository : IGenericRepository<CustomerConditionSync>
    {
        Task<CustomerConditionSync> GetByClientAndCondition(string clientCode, string condition);
    }
}
