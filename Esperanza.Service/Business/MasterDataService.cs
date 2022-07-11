using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;

namespace Esperanza.Service.Business
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IGenericRepository<DocumentType> DocumentTypeRepository;
        private readonly IGenericRepository<Sex> SexRepository;
        private readonly IGenericRepository<Country> CountryRepository;
        private readonly IGenericRepository<City> CityRepository;
        private readonly IGenericRepository<Neighborhood> NeighborhoodRepository;
        private readonly IGenericRepository<UserRole> UserRoleRepository;
        private readonly IGenericRepository<Category> CategoryRepository;
        private readonly IGenericRepository<Kind> KindRepository;
        private readonly IGenericRepository<Line> LineRepository;
        private readonly IGenericRepository<OrderStatus> OrderStatusRepository;
        private readonly IGenericRepository<Vademecum> VademecumRepository;
        private readonly IGenericRepository<SubCategory> SubCategoryRepository;
        private readonly IGenericRepository<SupplierItem> SupplierItemRepository;
        private readonly IGenericRepository<List> ListRepository;

        public MasterDataService(
            IGenericRepository<DocumentType> documentTypeRepository,
            IGenericRepository<Sex> sexRepository,
            IGenericRepository<Country> countryRepository,
            IGenericRepository<City> cityRepository,
            IGenericRepository<Neighborhood> neighborhoodRepository,
            IGenericRepository<UserRole> userRoleRepository,
            IGenericRepository<Category> categoryRepository,
            IGenericRepository<Kind> kindRepository,
            IGenericRepository<Line> lineRepository,
            IGenericRepository<OrderStatus> orderStatusRepository,
            IGenericRepository<Vademecum> vademecumRepository,
            IGenericRepository<SubCategory> subCategoryRepository,
            IGenericRepository<SupplierItem> supplierItemRepository,
            IGenericRepository<List> listRepository)
        {
            DocumentTypeRepository = documentTypeRepository;
            SexRepository = sexRepository;
            CountryRepository = countryRepository;
            CityRepository = cityRepository;
            NeighborhoodRepository = neighborhoodRepository;
            UserRoleRepository = userRoleRepository;
            CategoryRepository = categoryRepository;
            KindRepository = kindRepository;
            LineRepository = lineRepository;
            OrderStatusRepository = orderStatusRepository;
            VademecumRepository = vademecumRepository;
            SubCategoryRepository = subCategoryRepository;
            SupplierItemRepository = supplierItemRepository;
            ListRepository = listRepository;
        }

        public async Task<List<DocumentType>> GetAllTypesOfDocumentsAsync()
        {
            return (await DocumentTypeRepository.GetAllAsync()).ToList();
        }

        public async Task<List<Sex>> GetAllSexsAsync()
        {
            return (await SexRepository.GetAllAsync()).ToList();
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return (await CountryRepository.GetAllAsync()).ToList();
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            return (await CityRepository.GetAllAsync()).ToList();
        }

        public async Task<List<Neighborhood>> GetAllNeighborhoodsAsync()
        {
            return (await NeighborhoodRepository.GetAllAsync()).ToList();
        }

        public async Task<List<UserRole>> GetAllUserRolesAsync()
        {
            return (await UserRoleRepository.GetAllAsync()).ToList();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return (await CategoryRepository.GetAllAsync()).ToList();
        }

        public async Task<List<Kind>> GetAllKindsAsync()
        {
            return (await KindRepository.GetAllAsync()).ToList();
        }

        public async Task<List<Line>> GetAllLinesAsync()
        {
            return (await LineRepository.GetAllAsync()).ToList();
        }

        public async Task<List<OrderStatus>> GetAllOrderStatuesAsync()
        {
            return (await OrderStatusRepository.GetAllAsync()).ToList();
        }

        public async Task<List<List>> GetAllListsAsync()
        {
            return (await ListRepository.GetAllAsync()).ToList();
        }

        public async Task<List<Vademecum>> GetVademecumAsync()
        {
            return (await VademecumRepository.GetAllAsync()).ToList();
        }

        public async Task<List<SubCategory>> GetAllSubCategoriesAsync()
        {
            return (await SubCategoryRepository.GetAllAsync()).ToList();
        }

        public async Task<List<SupplierItem>> GetAllSupplierItemsAsync()
        {
            return (await SupplierItemRepository.GetAllAsync()).ToList();
        }
    }
}
