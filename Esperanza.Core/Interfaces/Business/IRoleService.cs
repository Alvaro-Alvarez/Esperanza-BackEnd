using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IRoleService
    {
        Task<UserRole> GetById(string guid);
        Task Insert(UserRole role, string userId);
        Task Update(UserRole role, string userId);
        Task Delete(string guid, string userId);
    }
}
