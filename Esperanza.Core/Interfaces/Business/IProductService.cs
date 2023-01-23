﻿using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.Response;
using Esperanza.Core.Models.Sync;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IProductService
    {
        Task<List<Product>> GetAllFull();
        Task<ProductsSyncResponseDTO> GetById(string guid, bool logged);
        Task<Product> InsertProduct(Product product, string userGuid);
        Task<Product> UpdateProduct(Product product, string userGuid);
        Task DeleteProduct(string guid, string userGuid);
        Task<bool> SyncProducts(List<ProductXLSX> productSyncs, string userGuid);
        Task<ProductsResponse> GetAllPaginated(Pagination pagination, string userGuid, bool logged);
        Task<List<Product>> GetAllLight();
    }
}
