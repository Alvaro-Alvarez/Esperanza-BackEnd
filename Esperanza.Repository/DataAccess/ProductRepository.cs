using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
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

        public async Task<List<Product>> GetAllLight()
        {
            List<Product> products;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<Product>(Product.GetAllLight)).ToList();
            }
            return products;
        }

        public async Task<List<Product>> GetAllFull()
        {
            List<Product> products;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<Product, PrincipalImage, Product>(
                    Product.GetAllLight, (product, principalImage) =>
                    {
                        product.PrincipalImage = principalImage;
                        return product;
                    }, splitOn: "Guid,Guid")).ToList();
            }
            return products;
        }

        public async Task<List<Product>> GetAllPaginated(Pagination pagination)
        {
            List<Product> products;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<Product, PrincipalImage, Vademecum, SubCategory, List, SupplierItem, Product>(
                    Product.GetAllWithPagination, (product, principalImage, vademecum, subCategory, list, supplierItem) =>
                    {
                        product.PrincipalImage = principalImage;
                        product.Vademecum = vademecum;
                        product.SubCategory = subCategory;
                        product.List = list;
                        product.SupplierItem = supplierItem;
                        return product;
                    }, new { Start = pagination.Start, End = pagination.End }, splitOn: "Guid,Guid,Guid,Guid,Guid")).ToList();
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

        public async Task<int> GetCount()
        {
            int rows;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                rows = (await db.QueryAsync<int>(Product.GetCount)).FirstOrDefault();
            }
            return rows;
        }
    }
}
