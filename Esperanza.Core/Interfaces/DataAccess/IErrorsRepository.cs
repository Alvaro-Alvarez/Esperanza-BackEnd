using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IErrorsRepository : IGenericRepository<Errors>
    {
        Task<string> InsertError(Errors error);
    }
}
