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
            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<IAppUserService, AppUserService>();
            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<IBasApiService, BasApiService>();
            services.AddSingleton<IHttpService, HttpService>();
            services.AddSingleton<IItemUpdateService, ItemUpdateService>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IImageService, ImageService>();
            services.AddSingleton<IVideoService, VideoService>();
            services.AddSingleton<ICarouselService, CarouselService>();
            services.AddSingleton<IPromotionalVideoService, PromotionalVideoService>();
            services.AddSingleton<ILaboratoryService, LaboratoryService>();
            services.AddSingleton<IContactService, ContactService>();
            #endregion

            #region Repositories
            services.AddSingleton<IPhoneRepository, PhoneRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IAppUserRepository, AppUserRepository>();
            services.AddSingleton<IEmailTemplateRepository, EmailTemplateRepository>();
            services.AddSingleton<IEmailKeysRepository, EmailKeysRepository>();
            services.AddSingleton<IGenericRepository<DocumentType>, DocumentTypeRepository>();
            services.AddSingleton<IConnectionBuilder, ConnectionBuilder>();
            services.AddSingleton<IGenericRepository<Sex>, SexRepository>();
            services.AddSingleton<IGenericRepository<PageType>, PageTypeRepository>();
            services.AddSingleton<IGenericRepository<UserRole>, UserRoleRepository>();
            services.AddSingleton<IGenericRepository<PriceListSync>, PriceListSyncRepository>();
            services.AddSingleton<ICustomerConditionSyncRepository, CustomerConditionSyncRepository>();
            services.AddSingleton<IGenericRepository<CustomerSync>, CustomerSyncRepository>();
            services.AddSingleton<IGenericRepository<PropductSync>, PropductSyncRepository>();
            services.AddSingleton<IGenericRepository<ConditionType>, ConditionTypeRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ILaboratoryRepository, LaboratoryRepository>();
            services.AddSingleton<IPromotionalVideoRepository, PromotionalVideoRepository>();
            services.AddSingleton<ICarouselSlideRepository, CarouselSlideRepository>();
            services.AddSingleton<ICarouselPageRepository, CarouselPageRepository>();
            services.AddSingleton<IPageTypeRepository, PageTypeRepository>();
            services.AddSingleton<IVideoRepository, VideoRepository>();
            services.AddSingleton<IImageRepository, ImageRepository>();
            services.AddSingleton<IErrorsRepository, ErrorsRepository>();
            services.AddSingleton<IConditionTypeRepository, ConditionTypeRepository>();

            #endregion

            #region Authorization
            services.AddSingleton<IReCaptcharService, ReCaptcharService>();
            #endregion

            return services;
        }
    }
}
