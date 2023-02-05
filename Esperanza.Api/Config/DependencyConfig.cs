using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Sync;
using Esperanza.Repository.DataAccess;
using Esperanza.Service.Business;

namespace Esperanza.Api.Config
{
    public static class DependencyConfig
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            #region Service
            services.AddSingleton<IMasterDataService, MasterDataService>();
            services.AddSingleton<IPhoneService, PhoneService>();
            services.AddSingleton<IAddressService, AddressService>();
            services.AddSingleton<IPrincipalImageService, PrincipalImageService>();
            services.AddSingleton<ICrossSellingService, CrossSellingService>();
            services.AddSingleton<IUpSellingService, UpSellingService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IGalleryImageService, GalleryImageService>();
            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<IAppUserService, AppUserService>();
            services.AddSingleton<IProductsOrderService, ProductsOrderService>();
            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<IBasApiService, BasApiService>();
            services.AddSingleton<IHttpService, HttpService>();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IItemUpdateService, ItemUpdateService>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IOrderService, OrderService>();
            #endregion

            #region Repositories
            services.AddSingleton<IPhoneRepository, PhoneRepository>();
            services.AddSingleton<IAddressRepository, AddressRepository>();
            services.AddSingleton<IPrincipalImageRepository, PrincipalImageRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IGalleryImageRepository, GalleryImageRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IAppUserRepository, AppUserRepository>();
            services.AddSingleton<IProductsOrderRepository, ProductsOrderRepository>();
            services.AddSingleton<ICrossSellingRepository, CrossSellingRepository>();
            services.AddSingleton<IUpSellingRepository, UpSellingRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IKindRepository, KindRepository>();
            services.AddSingleton<ILineRepository, LineRepository>();
            services.AddSingleton<IUserProductRepository, UserProductRepository>();
            services.AddSingleton<IEmailTemplateRepository, EmailTemplateRepository>();
            services.AddSingleton<IEmailKeysRepository, EmailKeysRepository>();

            services.AddSingleton<IConnectionBuilder, ConnectionBuilder>();
            services.AddSingleton<IGenericRepository<DocumentType>, DocumentTypeRepository>();
            services.AddSingleton<IGenericRepository<Sex>, SexRepository>();
            services.AddSingleton<IGenericRepository<Country>, CountryRepository>();
            services.AddSingleton<IGenericRepository<City>, CityRepository>();
            services.AddSingleton<IGenericRepository<Neighborhood>, NeighborhoodRepository>();
            services.AddSingleton<IGenericRepository<UserRole>, UserRoleRepository>();
            services.AddSingleton<IGenericRepository<OrderStatus>, OrderStatusRepository>();
            services.AddSingleton<IGenericRepository<Vademecum>, VademecumRepository>();
            services.AddSingleton<IGenericRepository<SubCategory>, SubCategoryRepository>();
            services.AddSingleton<IGenericRepository<SupplierItem>, SupplierItemRepository>();
            services.AddSingleton<IGenericRepository<List>, ListRepository>();
            services.AddSingleton<IGenericRepository<Laboratory>, LaboratoryRepository>();
            services.AddSingleton<IGenericRepository<TransportSync>, TransportSyncRepository>();
            services.AddSingleton<IGenericRepository<PriceListSync>, PriceListSyncRepository>();
            services.AddSingleton<ICustomerConditionSyncRepository, CustomerConditionSyncRepository>();
            services.AddSingleton<IGenericRepository<CustomerSync>, CustomerSyncRepository>();
            services.AddSingleton<IGenericRepository<PropductSync>, PropductSyncRepository>();

            #endregion

            #region Authorization
            services.AddSingleton<IReCaptcharService, ReCaptcharService>();
            #endregion

            return services;
        }
    }
}
