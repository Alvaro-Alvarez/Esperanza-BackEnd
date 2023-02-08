using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IMasterDataService
    {
        Task<List<DocumentType>> GetAllTypesOfDocumentsAsync();
        Task<List<Sex>> GetAllSexsAsync();
        Task<List<UserRole>> GetAllUserRolesAsync();
        Task<List<PageType>> GetPagesTypes();
    }
}
