using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<Person> GetFullPerson(Guid personGuid);
    }
}
