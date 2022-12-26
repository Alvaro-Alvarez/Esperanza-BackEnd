using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IUserProductRepository : IGenericRepository<UserProduct>
    {
        Task<List<UserProduct>> GetAllByUser(string userGuid);
    }
}
