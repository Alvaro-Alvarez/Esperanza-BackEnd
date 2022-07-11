using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Service.Helpers;

namespace Esperanza.Service.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository ProductRepository;
        private readonly ICrossSellingService CrossSellingService;
        private readonly IUpSellingService UpSellingService;
        private readonly IGalleryImageService GalleryImageService;
        private readonly IPrincipalImageService PrincipalImageService;
        private readonly IGenericRepository<Vademecum> VademecumeRepository;
        private readonly IGenericRepository<SubCategory> SubCategoryRepository;
        private readonly IGenericRepository<List> ListRepository;
        private readonly IGenericRepository<SupplierItem> SupplierItemRepository;

        public ProductService(
                    IProductRepository productRepository,
                    ICrossSellingService crossSellingService,
                    IUpSellingService upSellingService,
                    IGalleryImageService galleryImageService,
                    IPrincipalImageService principalImageService,
                    IGenericRepository<Vademecum> vademecumeRepository,
                    IGenericRepository<SubCategory> subCategoryRepository,
                    IGenericRepository<List> listRepository,
                    IGenericRepository<SupplierItem> supplierItemRepository
                    )
        {
            ProductRepository = productRepository;
            PrincipalImageService = principalImageService;
            VademecumeRepository = vademecumeRepository;
            SubCategoryRepository = subCategoryRepository;
            ListRepository = listRepository;
            SupplierItemRepository = supplierItemRepository;
            CrossSellingService = crossSellingService;
            UpSellingService = upSellingService;
            GalleryImageService = galleryImageService;
        }

        public async Task<List<Product>> GetAllFull()
        {
            return await ProductRepository.GetAllFull();
        }

        public async Task<Product> GetById(string guid)
        {
            return await ProductRepository.GetById(guid);
        }

        public async Task<Product>  InsertProduct(Product product, string userGuid)
        {
            product = InitNewProduct(userGuid, product);
            await PrincipalImageService.Insert(product.PrincipalImage);
            await VademecumeRepository.InsertAsync(product.Vademecum);
            await SubCategoryRepository.InsertAsync(product.SubCategory);
            await ListRepository.InsertAsync(product.List);
            await SupplierItemRepository.InsertAsync(product.SupplierItem);
            await CrossSellingService.Insert(product.CrossSelling);
            await UpSellingService.Insert(product.UpSelling);
            await ProductRepository.InsertAsync(product);
            return await GetById(product.Guid.ToString());
        }

        public async Task<Product> UpdateProduct(Product product, string userGuid)
        {
            product = InitUpdateProduct(product, userGuid);
            return new Product();
        }

        public async Task DeleteProduct(string guid, string userGuid)
        {
            var product = await GetById(guid);
            product = InitDeleteProduct(product, userGuid);
        }

        //TODO: Completar
        //public async Task<bool> SyncProducts(List<ProductSyncResponse> productSyncs)
        //{
        //    List<Product> products = new();
        //    foreach (var productSync in productSyncs)
        //    {
        //        Product product = InitNewProduct();
        //        product.Name = productSync.Name;
        //        products.Add(product);
        //    }
        //    //TODO: Completar
        //    return true;
        //}

        public async Task TestHangfire()
        {

        }

        #region Private Methods
        private Product InitNewProduct(string userGuid, Product product = null)
        {
            if (product == null)
            {
                product = new()
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
        #endregion
    }
}
