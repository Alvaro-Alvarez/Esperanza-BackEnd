using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IPhoneService
    {
        Task<Phone> InsertAsync(Phone phone, Guid userGuid);
        Task UpdateAsync(Phone phone, string userGuid);
        Task DeleteAsync(string guid, string updaterUserGuid);
    }
}
