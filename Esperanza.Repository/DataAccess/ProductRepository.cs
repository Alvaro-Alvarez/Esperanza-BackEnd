using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.Response;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;
        private readonly string NoLoggedColumn = "PRECIO_NL";

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

        public async Task<List<ProductsSyncResponseDTO>> GetAllPaginated(Pagination pagination, string clientCode)
        {
            List<ProductsSyncDTO> products;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<ProductsSyncDTO>(
                    Product.GetAllFullSync,
                    new { ClientCode = clientCode, Start = pagination.Start }
                    )).ToList();
            }
            return await GetProductsWithUpdatePrices(products);
        }

        public async Task<ProductsSyncResponseDTO> GetById(string cod)
        {
            ProductsSyncDTO product;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                product = (await db.QueryAsync<ProductsSyncDTO>(Product.GetByIdSync, new { Cod = cod })).FirstOrDefault();
            }
            return (await GetProductsWithUpdatePrices(new List<ProductsSyncDTO>() { product }, noLogged: false)).First();
        }

        public async Task<ProductsSyncResponseDTO> GetByIdNologged(string cod)
        {
            ProductsSyncDTO product;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                product = (await db.QueryAsync<ProductsSyncDTO>(Product.GetByIdSync, new { Cod = cod })).FirstOrDefault();
            }
            return (await GetProductsWithUpdatePrices(new List<ProductsSyncDTO>() { product }, noLogged: true)).First();
        }

        public async Task<int> GetCount(string clientCode)
        {
            int rows;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                rows = (await db.QueryAsync<int>(Product.GetAllFullCountSync, new { ClientCode = clientCode })).FirstOrDefault();
            }
            return rows;
        }

        public async Task<List<ProductsSyncResponseDTO>> GetAllNoLoggedPaginated(Pagination pagination)
        {
            List<ProductsSyncDTO> products;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<ProductsSyncDTO>(
                    Product.GetAllFullNoLoggedSync,
                    new { Start = pagination.Start }
                    )).ToList();
            }
            return await GetProductsWithUpdatePrices(products, noLogged: true);
        }

        public async Task<int> GetNoLoggedCount()
        {
            int rows;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                rows = (await db.QueryAsync<int>(Product.GetAllFullCountNoLoggedSync)).FirstOrDefault();
            }
            return rows;
        }

        private async Task<List<ProductsSyncResponseDTO>> GetProductsWithUpdatePrices(List<ProductsSyncDTO> products, bool noLogged = false)
        {
            List<ProductsSyncResponseDTO> newProducts = new List<ProductsSyncResponseDTO>();
            foreach (var product in products)
            {
                var price = product.GetType().GetProperty(noLogged ? NoLoggedColumn : product.COLUMNA_SELECCIONADA).GetValue(product, null);
                newProducts.Add(new ProductsSyncResponseDTO()
                {
                    CODIGO = product.CODIGO,
                    CBP = product.CBP,
                    MARCA = product.MARCA,
                    PROVEEDOR = product.PROVEEDOR,
                    SUBRUBRO = product.SUBRUBRO,
                    VADEMECUM = product.VADEMECUM,
                    ALTA = product.ALTA,
                    TIPO = product.TIPO,
                    LABORATORIO = product.LABORATORIO,
                    CATEGORIA = product.CATEGORIA,
                    LINEA_BAL = product.LINEA_BAL,
                    NOMBRE = product.NOMBRE,
                    DROGA = product.DROGA,
                    ACCION = product.ACCION,
                    DESCRIPCION = product.DESCRIPCION,
                    ESPECIE = product.ESPECIE,
                    VIA_ADMINISTRACION = product.VIA_ADMINISTRACION,
                    PRESENTACION = product.PRESENTACION,
                    RETIRO_LECHE = product.RETIRO_LECHE,
                    RETIRO_CARNE = product.RETIRO_CARNE,
                    DISCONTINUADO = product.DISCONTINUADO,
                    FALTANTE_INFO = product.FALTANTE_INFO,
                    FALTANTE_FOTO = product.FALTANTE_FOTO,
                    OBS = product.OBS,
                    FECHAREG = product.FECHAREG,
                    FOTO = product.FOTO,
                    CONDICION = product.CONDICION,
                    PRECIO = price?.ToString(),
                    LOGGED = noLogged ? false: true
                });
            }
            return newProducts;
        }
    }
}
