using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IEmailKeysRepository : IGenericRepository<EmailKeys>
    {
        Task<List<EmailKeys>> GetByTemplate(Guid idTemplate);
    }
}
