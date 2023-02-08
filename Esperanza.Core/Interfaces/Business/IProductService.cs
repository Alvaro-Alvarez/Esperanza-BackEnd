using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.Response;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IProductService
    {
        Task<ProductsSyncResponseDTO> GetById(string guid, bool logged, string userGuid);
        Task<ProductsResponse> GetAllPaginated(Filter filter, string userGuid, bool logged);
    }
}
