using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public ProductRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.Product, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }

        public async Task<List<Product>> GetAllFull()
        {
            List<Product> products;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<Product, PrincipalImage, Vademecum, SubCategory, List, SupplierItem, Product>(
                    Product.GetAllFull, (product, principalImage, vademecum, subCategory, list, supplierItem) =>
                    {
                        product.PrincipalImage = principalImage;
                        product.Vademecum = vademecum;
                        product.SubCategory = subCategory;
                        product.List = list;
                        product.SupplierItem = supplierItem;
                        return product;
                    }, splitOn: "Guid,Guid,Guid,Guid,Guid")).ToList();
            }
            return products;
        }

        public async Task<Product> GetById(string guid)
        {
            Product product;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                product = (await db.QueryAsync<Product, PrincipalImage, Vademecum, SubCategory, List, SupplierItem, Product>(
                    Product.GetById, (product, principalImage, vademecum, subCategory, list, supplierItem) =>
                    {
                        product.PrincipalImage = principalImage;
                        product.Vademecum = vademecum;
                        product.SubCategory = subCategory;
                        product.List = list;
                        product.SupplierItem = supplierItem;
                        return product;
                    }, new { Guid = guid }, splitOn: "Guid,Guid,Guid,Guid,Guid")).FirstOrDefault();
            }
            return product;
        }
    }
}
