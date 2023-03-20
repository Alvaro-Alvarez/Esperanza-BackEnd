using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.Response;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IProductService
    {
        Task<ProductsResponse> GetTopFive(string userGuid, bool logged);
        Task<ProductsResponse> GetAllByLaboratory(GetByLaboratory filter, string userGuid, bool logged);
        Task<ProductsSyncResponseDTO> GetById(string guid, bool logged, string userGuid);
        Task<ProductsResponse> GetAllPaginated(Filter filter, string userGuid, bool logged);
        Task<ProductsResponse> GetAllRecommended(GetRecommended request, string userGuid);
        Task<List<string>> GetImagesByCodes(GetRecommended request);
        Task<ProductsResponse> GetByVademecumFilter(VademecumFilter filter, string userGuid);
    }
}
