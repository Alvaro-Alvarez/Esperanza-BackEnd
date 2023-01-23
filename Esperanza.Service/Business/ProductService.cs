using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.Response;
using Esperanza.Core.Models.Sync;
using Esperanza.Service.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Esperanza.Service.Business
{
    public class ProductService : IProductService
    {
        private readonly IBasApiService BasApiService;
        private readonly IAppUserRepository UserRepository;
        private readonly IProductRepository ProductRepository;
        private readonly ICrossSellingService CrossSellingService;
        private readonly IUpSellingService UpSellingService;
        private readonly IGalleryImageService GalleryImageService;
        private readonly IPrincipalImageService PrincipalImageService;
        private readonly IGenericRepository<Vademecum> VademecumeRepository;
        private readonly IGenericRepository<SubCategory> SubCategoryRepository;
        private readonly IGenericRepository<List> ListRepository;
        private readonly IGenericRepository<SupplierItem> SupplierItemRepository;
        private readonly IGenericRepository<Laboratory> LaboratoryRepository;

        private readonly IKindRepository KindRepository;
        private readonly ICategoryRepository CategoryRepository;
        private readonly ILineRepository LineRepository;

        public ProductService(
                    IBasApiService basApiService,
                    IAppUserRepository userRepository,
                    IProductRepository productRepository,
                    ICrossSellingService crossSellingService,
                    IUpSellingService upSellingService,
                    IGalleryImageService galleryImageService,
                    IPrincipalImageService principalImageService,
                    IGenericRepository<Vademecum> vademecumeRepository,
                    IGenericRepository<SubCategory> subCategoryRepository,
                    IGenericRepository<List> listRepository,
                    IGenericRepository<SupplierItem> supplierItemRepository,
                    IGenericRepository<Laboratory> laboratoryRepository,
                    IKindRepository kindRepository,
                    ICategoryRepository categoryRepository,
                    ILineRepository lineRepository
                    )
        {
            BasApiService = basApiService;
            UserRepository = userRepository;
            ProductRepository = productRepository;
            PrincipalImageService = principalImageService;
            VademecumeRepository = vademecumeRepository;
            SubCategoryRepository = subCategoryRepository;
            ListRepository = listRepository;
            SupplierItemRepository = supplierItemRepository;
            CrossSellingService = crossSellingService;
            UpSellingService = upSellingService;
            GalleryImageService = galleryImageService;
            LaboratoryRepository = laboratoryRepository;
            KindRepository = kindRepository;
            CategoryRepository = categoryRepository;
            LineRepository = lineRepository;
        }

        public async Task<List<Product>> GetAllFull()
        {
            return await ProductRepository.GetAllFull();
        }

        public async Task<List<Product>> GetAllLight()
        {
            return await ProductRepository.GetAllLight();
        }

        public async Task<ProductsResponse> GetAllPaginated(Pagination pagination, string userGuid, bool logged)
        {
            var products = new List<ProductsSyncResponseDTO>();
            var user = new AppUser();
            if (logged) user = await UserRepository.GetAsync(userGuid);
            if (logged) products = await ProductRepository.GetAllPaginated(pagination, user.BasClientCode);
            else products = await ProductRepository.GetAllNoLoggedPaginated(pagination);
            //await InsertPrices(products, user);
            return new ProductsResponse()
            {
                Products = products,
                Rows = logged ? await ProductRepository.GetCount(user.BasClientCode) : await ProductRepository.GetNoLoggedCount()
            };
        }

        public async Task<ProductsSyncResponseDTO> GetById(string cod, bool logged)
        {
            var product = new ProductsSyncResponseDTO();
            if (logged) product = await ProductRepository.GetById(cod);
            else product = await ProductRepository.GetByIdNologged(cod);
            //product.Kinds = await KindRepository.GetAllByProductId(guid);
            //product.Categories = await CategoryRepository.GetAllByProductId(guid);
            //product.Lines = await LineRepository.GetAllByProductId(guid);
            return product;
        }

        public async Task<Product>  InsertProduct(Product product, string userGuid)
        {
            if (product.LaboratoryGuid.Equals(Guid.Empty)) product.LaboratoryGuid = null;
            product = InitNewProduct(userGuid, product);
            await PrincipalImageService.Insert(product.PrincipalImage);
            await VademecumeRepository.InsertAsync(product.Vademecum);
            await SubCategoryRepository.InsertAsync(product.SubCategory);
            await ListRepository.InsertAsync(product.List);
            await SupplierItemRepository.InsertAsync(product.SupplierItem);
            await CrossSellingService.Insert(product.CrossSelling);
            await UpSellingService.Insert(product.UpSelling);
            await ProductRepository.InsertAsync(product);
            await KindRepository.InsertManyToMany(product.KindGuids, product.Guid.Value);
            await CategoryRepository.InsertManyToMany(product.CategoryGuids, product.Guid.Value);
            await LineRepository.InsertManyToMany(product.LineGuids, product.Guid.Value);
            //return await GetById(product.Guid.ToString());
            return new Product();
        }

        public async Task<Product> UpdateProduct(Product product, string userGuid)
        {
            product = InitUpdateProduct(product, userGuid);
            return new Product();
        }

        public async Task DeleteProduct(string guid, string userGuid)
        {
            //var product = await GetById(guid);
            //product = InitDeleteProduct(product, userGuid);
        }

        //TODO: Completar
        public async Task<bool> SyncProducts(List<ProductXLSX> productSyncs, string userGuid)
        {
            List<Product> products = new();
            foreach (var productSync in productSyncs)
            {
                Product product = GetEmptyProduct();
                product = InitNewProduct(userGuid, product);
                product.Name = productSync.Nombre;
                product.Description = productSync.Description;
                product.BasProductCode = productSync.Id;
                product.MainComponent = productSync.ComponentePrincipal;
                product.Drug = productSync.Droga;
                product.Action = productSync.Accion;
                product.Presentation = productSync.Presentacion;
                product.RoutesOfAdministration = productSync.ViasDeAdminstracion;
                product.MilkWithdrawal = productSync.RetiroLeche;
                product.MeatRecall = productSync.RetiroCarne;
                product.Discontinued = GetBoolByValue(productSync.Discontinuado);
                product.MissingInformation = GetBoolByValue(productSync.FaltanteInfo);
                product.MissingFoto = GetBoolByValue(productSync.FaltanteFoto);
                product.OBS = productSync.OBS;
                product.LaboratoryGuid = GetGuid(await LaboratoryRepository.GetByName(productSync.Laboratorio));
                product.SubCategoryGuid = GetGuid(await SubCategoryRepository.GetByName(productSync.Tipo));
                product.CategoryGuids = GetRangeOfGuids((await CategoryRepository.GetRangeByName(productSync.Categoria?.Split(",").ToList())).ToList());
                product.KindGuids = GetRangeOfGuids((await KindRepository.GetRangeByName(productSync.Especie?.Split(",").ToList())).ToList());
                product.LineGuids = GetRangeOfGuids((await LineRepository.GetRangeByName(productSync.LineaBal?.Split(",").ToList())).ToList());
                products.Add(product);
            }
            //TODO: Completar
            //await InsertProduct(products.FirstOrDefault(), userGuid);
            foreach (var product in products)
                await InsertProduct(product, userGuid);
            return true;
        }

        public async Task TestHangfire()
        {

        }

        #region Private Methods
        private Product InitNewProduct(string userGuid, Product product = null)
        {
            if (product == null) product = GetEmptyProduct();
            EntityHelper.InitEntity(product, new Guid(userGuid));
            EntityHelper.InitEntity(product.PrincipalImage, new Guid(userGuid));
            EntityHelper.InitEntity(product.UpSelling, new Guid(userGuid));
            EntityHelper.InitEntity(product.CrossSelling, new Guid(userGuid));
            EntityHelper.InitEntity(product.Vademecum, new Guid(userGuid));
            EntityHelper.InitEntity(product.SubCategory, new Guid(userGuid));
            EntityHelper.InitEntity(product.List, new Guid(userGuid));
            EntityHelper.InitEntity(product.SupplierItem, new Guid(userGuid));
            product.PrincipalImageGuid = product.PrincipalImage.Guid.Value;
            product.UpSellingGuid = product.UpSelling.Guid.Value;
            product.CrossSellingGuid = product.CrossSelling.Guid.Value;
            product.VademecumGuid = product.Vademecum.Guid.Value;
            product.SubCategoryGuid = product.SubCategory.Guid.Value;
            product.ListGuid = product.List.Guid.Value;
            product.SupplierItemGuid = product.SupplierItem.Guid.Value;
            return product;
        }
        private Product InitUpdateProduct(Product product, string userGuid)
        {
            EntityHelper.ModifyEntity(product, new Guid(userGuid));
            EntityHelper.ModifyEntity(product.PrincipalImage, new Guid(userGuid));
            EntityHelper.ModifyEntity(product.UpSelling, new Guid(userGuid));
            EntityHelper.ModifyEntity(product.CrossSelling, new Guid(userGuid));
            EntityHelper.ModifyEntity(product.Vademecum, new Guid(userGuid));
            EntityHelper.ModifyEntity(product.SubCategory, new Guid(userGuid));
            EntityHelper.ModifyEntity(product.List, new Guid(userGuid));
            EntityHelper.ModifyEntity(product.SupplierItem, new Guid(userGuid));
            return product;
        }
        private Product InitDeleteProduct(Product product, string userGuid)
        {
            EntityHelper.ModifyEntity(product, new Guid(userGuid), delete: true);
            EntityHelper.ModifyEntity(product.PrincipalImage, new Guid(userGuid), delete: true);
            EntityHelper.ModifyEntity(product.UpSelling, new Guid(userGuid), delete: true);
            EntityHelper.ModifyEntity(product.CrossSelling, new Guid(userGuid), delete: true);
            EntityHelper.ModifyEntity(product.Vademecum, new Guid(userGuid), delete: true);
            EntityHelper.ModifyEntity(product.SubCategory, new Guid(userGuid), delete: true);
            EntityHelper.ModifyEntity(product.List, new Guid(userGuid), delete: true);
            EntityHelper.ModifyEntity(product.SupplierItem, new Guid(userGuid), delete: true);
            return product;
        }
        private Product GetEmptyProduct()
        {
            return new()
            {
                PrincipalImage = new PrincipalImage(),
                UpSelling = new UpSelling(),
                CrossSelling = new CrossSelling(),
                Vademecum = new Vademecum(),
                SubCategory = new SubCategory(),
                List = new List(),
                SupplierItem = new SupplierItem()
            };
        }
        private bool GetBoolByValue(string value)
        {
            return string.IsNullOrEmpty(value) || value == "NO" ? false : true;
        }
        private Guid GetGuid(Entity entity)
        {
            if (entity != null) return entity.Guid.Value;
            return Guid.Empty;
        }
        private List<Guid> GetRangeOfGuids(object entitiesObj)
        {
            List<Guid> guids = new();
            var arr = JArray.Parse(JsonConvert.SerializeObject(entitiesObj));
            foreach (JObject obj in arr.Children())
            {
                foreach (JProperty prop in obj.Children())
                {
                    if (!string.IsNullOrEmpty(prop.Name) && !string.IsNullOrEmpty(prop.Value.ToString()))
                    {
                        if (prop.Name.ToString() == "Guid")
                            guids.Add(new Guid(prop.Value.ToString()));
                    }
                }
            }
            return guids;
        }

        private async Task InsertPrices(List<Product> products, AppUser user)
        {
            foreach (Product product in products)
            {
                ProductResponse productCCM = new ProductResponse();
                ProductResponse productCCB = new ProductResponse();
                if (user.CanCCM.Value)
                    productCCM = await BasApiService.GetProductCCMBas(user.BasClientCode, product.BasProductCode);
                if (user.CanCCB.Value)
                    productCCB = await BasApiService.GetProductCCBBas(user.BasClientCode, product.BasProductCode);
                decimal CCMPrice = !string.IsNullOrEmpty(productCCM.Codigo) ? Convert.ToDecimal(productCCM.Precio) : 0;
                decimal CCBPrice = !string.IsNullOrEmpty(productCCB.Codigo) ? Convert.ToDecimal(productCCB.Precio) : 0;
                product.UnitPrice = new List<decimal>() { CCMPrice, CCBPrice }.Max();
            }
        }
        #endregion
    }
}
