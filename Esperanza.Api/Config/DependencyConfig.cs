using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
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

            services.AddSingleton<IConnectionBuilder, ConnectionBuilder>();
            services.AddSingleton<IGenericRepository<DocumentType>, DocumentTypeRepository>();
            services.AddSingleton<IGenericRepository<Sex>, SexRepository>();
            services.AddSingleton<IGenericRepository<Country>, CountryRepository>();
            services.AddSingleton<IGenericRepository<City>, CityRepository>();
            services.AddSingleton<IGenericRepository<Neighborhood>, NeighborhoodRepository>();
            services.AddSingleton<IGenericRepository<UserRole>, UserRoleRepository>();
            services.AddSingleton<IGenericRepository<Category>, CategoryRepository>();
            services.AddSingleton<IGenericRepository<Kind>, KindRepository>();
            services.AddSingleton<IGenericRepository<Line>, LineRepository>();
            services.AddSingleton<IGenericRepository<OrderStatus>, OrderStatusRepository>();
            services.AddSingleton<IGenericRepository<Vademecum>, VademecumRepository>();
            services.AddSingleton<IGenericRepository<SubCategory>, SubCategoryRepository>();
            services.AddSingleton<IGenericRepository<SupplierItem>, SupplierItemRepository>();
            services.AddSingleton<IGenericRepository<List>, ListRepository>();
            #endregion

            #region Authorization
            services.AddSingleton<IReCaptcharService, ReCaptcharService>();
            #endregion

            return services;
        }
    }
}
