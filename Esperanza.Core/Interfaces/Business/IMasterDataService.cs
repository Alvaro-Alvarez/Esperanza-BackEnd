using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IMasterDataService
    {
        Task<List<DocumentType>> GetAllTypesOfDocumentsAsync();
        Task<List<Sex>> GetAllSexsAsync();
        Task<List<Country>> GetAllCountriesAsync();
        Task<List<City>> GetAllCitiesAsync();
        Task<List<Neighborhood>> GetAllNeighborhoodsAsync();
        Task<List<UserRole>> GetAllUserRolesAsync();
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Kind>> GetAllKindsAsync();
        Task<List<Line>> GetAllLinesAsync();
        Task<List<OrderStatus>> GetAllOrderStatuesAsync();
    }
}
