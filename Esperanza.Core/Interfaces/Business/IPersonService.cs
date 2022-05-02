using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IPersonService
    {
        Task<Person> GetByGuidAsync(string personGuid);
        Task<Person> InsertAsync(Person person, Guid userGuid);
        Task UpdateAsync(Person person, string userGuid);
        Task DeleteAsync(string personGuid, string updaterUserGuid);
    }
}
