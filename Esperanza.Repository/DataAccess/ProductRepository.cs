using Dapper;
using Esperanza.Core.Enums;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.Response;
using Esperanza.Core.Models.SPs;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;
        private readonly string NoLoggedColumn = "PRECIO_NL1";

        public ProductRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.PropductSync, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }

        public async Task<List<ProductsSyncResponseDTO>> GetAllByLaboratory(GetByLaboratory filter, bool logged, string clitenCode)
        {
            List<ProductsSyncDTO> products;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = db.Query<ProductsSyncDTO>("GetProductsByLaboratory", new {
                    Start = filter.Start,
                    Logged = logged,
                    ClientCode = clitenCode,
                    Laboratory = filter.Laboratory,
                }, commandType: CommandType.StoredProcedure).ToList();
            }
            return await GetProductsWithUpdatePrices(products, noLogged: true);
        }

        public async Task<List<ProductsSyncResponseDTO>> GetTopFive(bool logged, string clitenCode)
        {
            List<ProductsSyncDTO> products;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = db.Query<ProductsSyncDTO>("GetProductsTopFive", new
                {
                    Logged = logged,
                    ClientCode = clitenCode
                }, commandType: CommandType.StoredProcedure).ToList();
            }
            return await GetProductsWithUpdatePrices(products, noLogged: clitenCode == "001" || clitenCode == null);
            //return await GetProductsWithUpdatePrices(products, noLogged: false);
        }

        public async Task<List<ProductsSyncResponseDTO>> GetAllPaginatedNew(Filter filter, bool logged, string clientCode)
        {
            List<ProductsSyncDTO> products;
            if (filter.Condiciones.Count == 0)
            {
                filter.Condiciones.Add("CCM");
                filter.Condiciones.Add("CCB");
            }
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = db.Query<ProductsSyncDTO>("GetProducts", new
                {
                    Search = filter.Search,
                    Conditions = string.Join(",", filter.Condiciones),
                    ClientCode = clientCode,
                    Start = filter.Start,
                    Marca = filter.Marcas,
                    Proveedor = filter.Proveedores,
                    Subrubro = filter.Subrubros,
                    Vademecum = filter.Vademecums,
                    Tipo = filter.Tipos,
                    Laboratorio = filter.Laboratorios,
                    Categoria = filter.Categorias,
                    Droga = filter.Drogas,
                    Accion = filter.Acciones,
                    Especie = filter.Especies,
                    ViaAdministracion = filter.ViaAdministraciones
                }, commandType: CommandType.StoredProcedure).ToList();
            }
            return await GetProductsWithUpdatePrices(products);
        }

        public async Task<List<ProductsSyncResponseDTO>> GetAllPaginated(Filter filter, string clientCode)
        {
            List<ProductsSyncDTO> products;
            string query = Product.GetAllFullSync.Replace("@Search", filter.Search);
            query = query.Replace("@ConditionFilter", GetConditionFilter(filter.Condiciones));
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<ProductsSyncDTO>(
                    query,
                    new 
                    {
                        ClientCode = clientCode,
                        Start = filter.Start,
                        Marca = filter.Marcas,
                        Proveedor = filter.Proveedores,
                        Subrubro = filter.Subrubros,
                        Vademecum = filter.Vademecums,
                        Tipo = filter.Tipos,
                        Laboratorio = filter.Laboratorios,
                        Categoria = filter.Categorias,
                        Droga = filter.Drogas,
                        Accion = filter.Acciones,
                        Especie = filter.Especies,
                        ViaAdministracion = filter.ViaAdministraciones
                    }
                    )).ToList();
            }
            return await GetProductsWithUpdatePrices(products);
        }

        public async Task<ProductsSyncResponseDTO> GetById(string cod, string clientCode)
        {
            ProductsSyncDTO product;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                product = (await db.QueryAsync<ProductsSyncDTO>(Product.GetByIdSync, new { Cod = cod, ClientCode = clientCode })).FirstOrDefault();
            }
            return (await GetProductsWithUpdatePrices(new List<ProductsSyncDTO>() { product }, noLogged: false)).First();
        }

        public async Task<ProductsSyncResponseDTO> GetByIdNologged(string cod)
        {
            ProductsSyncDTO product;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                product = (await db.QueryAsync<ProductsSyncDTO>(Product.GetByIdNoLoggedSync, new { Cod = cod })).FirstOrDefault();
            }
            return (await GetProductsWithUpdatePrices(new List<ProductsSyncDTO>() { product }, noLogged: true)).First();
        }

        public async Task<int> GetCount(string clientCode, Filter filter)
        {
            int rows;
            string query = Product.GetAllFullCountSync.Replace("@Search", filter.Search);
            query = query.Replace("@ConditionFilter", GetConditionFilter(filter.Condiciones));
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                rows = (await db.QueryAsync<int>(query, new
                {
                    ClientCode = clientCode,
                    Marca = filter.Marcas,
                    Proveedor = filter.Proveedores,
                    Subrubro = filter.Subrubros,
                    Vademecum = filter.Vademecums,
                    Tipo = filter.Tipos,
                    Laboratorio = filter.Laboratorios,
                    Categoria = filter.Categorias,
                    Droga = filter.Drogas,
                    Accion = filter.Acciones,
                    Especie = filter.Especies,
                    ViaAdministracion = filter.ViaAdministraciones
                })).FirstOrDefault();
            }
            return rows;
        }

        public async Task<List<ProductsSyncResponseDTO>> GetAllNoLoggedPaginated(Filter filter)
        {
            List<ProductsSyncDTO> products;
            string query = Product.GetAllFullNoLoggedSync.Replace("@Search", filter.Search);
            query = query.Replace("@ConditionFilter", GetConditionFilter(filter.Condiciones));
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<ProductsSyncDTO>(
                    query,
                    new {
                        Start = filter.Start,
                        Marca = filter.Marcas,
                        Proveedor = filter.Proveedores,
                        Subrubro = filter.Subrubros,
                        Vademecum = filter.Vademecums,
                        Tipo = filter.Tipos,
                        Laboratorio = filter.Laboratorios,
                        Categoria = filter.Categorias,
                        Droga = filter.Drogas,
                        Accion = filter.Acciones,
                        Especie = filter.Especies,
                        ViaAdministracion = filter.ViaAdministraciones
                    }
                    )).ToList();
            }
            return await GetProductsWithUpdatePrices(products, noLogged: true);
        }

        public async Task<int> GetNoLoggedCount(Filter filter)
        {
            int rows;
            string query = Product.GetAllFullCountNoLoggedSync.Replace("@Search", filter.Search);
            query = query.Replace("@ConditionFilter", GetConditionFilter(filter.Condiciones));
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                rows = (await db.QueryAsync<int>(query, new
                {
                    Marca = filter.Marcas,
                    Proveedor = filter.Proveedores,
                    Subrubro = filter.Subrubros,
                    Vademecum = filter.Vademecums,
                    Tipo = filter.Tipos,
                    Laboratorio = filter.Laboratorios,
                    Categoria = filter.Categorias,
                    Droga = filter.Drogas,
                    Accion = filter.Acciones,
                    Especie = filter.Especies,
                    ViaAdministracion = filter.ViaAdministraciones
                })).FirstOrDefault();
            }
            return rows;
        }

        public async Task<ValuesToFilter> GetValuesToFilter(Filter filter, string clientCode)
        {
            List<ProductsSyncDTO> products;
            string query = Product.GetAllFullSyncNoPagination.Replace("@Search", filter.Search);
            query = query.Replace("@ConditionFilter", GetConditionFilter(filter.Condiciones));
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<ProductsSyncDTO>(
                    query,
                    new 
                    {
                        ClientCode = clientCode,
                        Marca = filter.Marcas,
                        Proveedor = filter.Proveedores,
                        Subrubro = filter.Subrubros,
                        Vademecum = filter.Vademecums,
                        Tipo = filter.Tipos,
                        Laboratorio = filter.Laboratorios,
                        Categoria = filter.Categorias,
                        Droga = filter.Drogas,
                        Accion = filter.Acciones,
                        Especie = filter.Especies,
                        ViaAdministracion = filter.ViaAdministraciones
                    }
                    )).ToList();
            }
            return await FillValuesToFilter(products);
        }

        public async Task<ValuesToFilter> GetValuesToFilterNew(Filter filter, bool logged, string clientCode)
        {
            List<ProductsSyncDTO> products;
            if (filter.Condiciones.Count == 0)
            {
                filter.Condiciones.Add("CCM");
                filter.Condiciones.Add("CCB");
            }
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = db.Query<ProductsSyncDTO>("GetProductsForFilter", new
                {
                    Search = filter.Search,
                    Conditions = string.Join(",", filter.Condiciones),
                    ClientCode = clientCode,
                    Start = filter.Start,
                    Marca = filter.Marcas,
                    Proveedor = filter.Proveedores,
                    Subrubro = filter.Subrubros,
                    Vademecum = filter.Vademecums,
                    Tipo = filter.Tipos,
                    Laboratorio = filter.Laboratorios,
                    Categoria = filter.Categorias,
                    Droga = filter.Drogas,
                    Accion = filter.Acciones,
                    Especie = filter.Especies,
                    ViaAdministracion = filter.ViaAdministraciones
                }, commandType: CommandType.StoredProcedure).ToList();
            }
            return await FillValuesToFilter(products);
        }

        public async Task<ValuesToFilter> GetValuesToFilterNoLogged(Filter filter)
        {
            List<ProductsSyncDTO> products;
            string query = Product.GetAllFullNoLoggedSyncNoPagination.Replace("@Search", filter.Search);
            query = query.Replace("@ConditionFilter", GetConditionFilter(filter.Condiciones));
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<ProductsSyncDTO>(query, new
                {
                    Marca = filter.Marcas,
                    Proveedor = filter.Proveedores,
                    Subrubro = filter.Subrubros,
                    Vademecum = filter.Vademecums,
                    Tipo = filter.Tipos,
                    Laboratorio = filter.Laboratorios,
                    Categoria = filter.Categorias,
                    Droga = filter.Drogas,
                    Accion = filter.Acciones,
                    Especie = filter.Especies,
                    ViaAdministracion = filter.ViaAdministraciones
                })).ToList();
            }
            return await FillValuesToFilter(products);
        }

        public async Task<List<ProductsSyncDTO>> GetAlll(Filter filter, string clientCode)
        {
            List<ProductsSyncDTO> products;
            string query = Product.GetAllFullSyncNoPagination.Replace("@Search", filter.Search);
            query = query.Replace("@ConditionFilter", GetConditionFilter(filter.Condiciones));
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<ProductsSyncDTO>(
                    query,
                    new
                    {
                        ClientCode = clientCode,
                        Marca = filter.Marcas,
                        Proveedor = filter.Proveedores,
                        Subrubro = filter.Subrubros,
                        Vademecum = filter.Vademecums,
                        Tipo = filter.Tipos,
                        Laboratorio = filter.Laboratorios,
                        Categoria = filter.Categorias,
                        Droga = filter.Drogas,
                        Accion = filter.Acciones,
                        Especie = filter.Especies,
                        ViaAdministracion = filter.ViaAdministraciones
                    }
                    )).ToList();
            }
            return products;
        }

        public async Task<List<ProductsSyncDTO>> GetAllRecommended(GetRecommended request, string clientCode)
        {
            List<ProductsSyncDTO> products;
            //var asd = string.Join(", ", request.ProductCodes);
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<ProductsSyncDTO>(Product.GetAllRecommended, new { ProductCodes = request.ProductCodes, ClientCode = clientCode })).ToList();
            }
            return products;
        }

        public async Task<List<ProductsSyncDTO>> GetByVademecumFilter(VademecumFilter filter, string clientCode)
        {
            List<ProductsSyncDTO> products;
            if (filter.Condiciones.Count == 0)
            {
                filter.Condiciones.Add("CCM");
                filter.Condiciones.Add("CCB");
            }
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = db.Query<ProductsSyncDTO>("GetProductsByVademecumFilter", new
                {
                    Condiciones = string.Join(",", filter.Condiciones),
                    ClientCode = clientCode,
                    Logged = clientCode != "001",
                    Start = filter.Start,
                    Accion = filter.Accion,
                    Especie = filter.Especie,
                    Administracion = filter.Administracion,
                    Droga = filter.Droga
                }, commandType: CommandType.StoredProcedure).ToList();
            }
            return products;
        }

        public async Task<List<ProductsSyncDTO>> GetAlllNoLogged(Filter filter)
        {
            List<ProductsSyncDTO> products;
            string query = Product.GetAllFullNoLoggedSyncNoPagination.Replace("@Search", filter.Search);
            query = query.Replace("@ConditionFilter", GetConditionFilter(filter.Condiciones));
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                products = (await db.QueryAsync<ProductsSyncDTO>(query, new
                {
                    Marca = filter.Marcas,
                    Proveedor = filter.Proveedores,
                    Subrubro = filter.Subrubros,
                    Vademecum = filter.Vademecums,
                    Tipo = filter.Tipos,
                    Laboratorio = filter.Laboratorios,
                    Categoria = filter.Categorias,
                    Droga = filter.Drogas,
                    Accion = filter.Acciones,
                    Especie = filter.Especies,
                    ViaAdministracion = filter.ViaAdministraciones
                })).ToList();
            }
            return products;
        }

        public async Task<List<string>> GetImagesByCodes(GetRecommended request)
        {
            var codes = request.ProductCodes.Distinct().ToList();
            List<string> images;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                images = (await db.QueryAsync<string>(Product.GetImagesByCodes, new { Codes = codes })).ToList();
            }
            return images;
        }

        #region Private Methods
        public async Task<ValuesToFilter> FillValuesToFilter(List<ProductsSyncDTO> products)
        {
            var marcas = products.Where(p => !string.IsNullOrEmpty(p.MARCA)).Select(p => p.MARCA).Distinct().ToList();
            var proveedores = products.Where(p => !string.IsNullOrEmpty(p.PROVEEDOR)).Select(p => p.PROVEEDOR).Distinct().ToList();
            var subrubros = products.Where(p => !string.IsNullOrEmpty(p.SUBRUBRO)).Select(p => p.SUBRUBRO).Distinct().ToList();
            //var vademecums = products.Where(p => !string.IsNullOrEmpty(p.VADEMECUM)).Select(p => p.VADEMECUM).Distinct().ToList();
            //var tipos = products.Where(p => !string.IsNullOrEmpty(p.TIPO)).Select(p => p.TIPO).Distinct().ToList();
            //var laboratorios = products.Where(p => !string.IsNullOrEmpty(p.LABORATORIO)).Select(p => p.LABORATORIO).Distinct().ToList();
            //var categorias = products.Where(p => !string.IsNullOrEmpty(p.CATEGORIA)).Select(p => p.CATEGORIA).Distinct().ToList();
            //var drogas = products.Where(p => !string.IsNullOrEmpty(p.DROGA)).Select(p => p.DROGA).Distinct().ToList();
            ////var acciones = products.Where(p => !string.IsNullOrEmpty(p.ACCION)).Select(p => p.ACCION).Distinct().ToList();
            //var especies = products.Where(p => !string.IsNullOrEmpty(p.ESPECIE)).Select(p => p.ESPECIE).Distinct().ToList();
            //var viaAdministraciones = products.Where(p => !string.IsNullOrEmpty(p.VIA_ADMINISTRACION)).Select(p => p.VIA_ADMINISTRACION).Distinct().ToList();

            var marcaTuple = await GetItemsFilters(products, marcas, ProductFieldTypeEnum.Marca);
            var proveedorTuple = await GetItemsFilters(products, proveedores, ProductFieldTypeEnum.Proveedor);
            var subrubroTuple = await GetItemsFilters(products, subrubros, ProductFieldTypeEnum.Subrubro);
            //var vademecumTuple = await GetItemsFilters(products, vademecums, ProductFieldTypeEnum.Vademecum);
            //var tipoTuple = await GetItemsFilters(products, tipos, ProductFieldTypeEnum.Tipo);
            //var laboratorioTuple = await GetItemsFilters(products, laboratorios, ProductFieldTypeEnum.Laboratorio);
            //var categoriaTuple = await GetItemsFilters(products, categorias, ProductFieldTypeEnum.Categoria);
            //var drogaTuple = await GetItemsFilters(products, drogas, ProductFieldTypeEnum.Droga);
            ////var accionTuple = await GetItemsFilters(products, acciones, ProductFieldTypeEnum.Accion);
            //var especieTuple = await GetItemsFilters(products, especies, ProductFieldTypeEnum.Especie);
            //var viaAdministracionTuple = await GetItemsFilters(products, viaAdministraciones, ProductFieldTypeEnum.ViaAdministracion);

            return new ValuesToFilter()
            {
                Marca = new CategoryFilter() { ItemsFilter = marcaTuple.Item1, CanFilter = marcaTuple.Item2 },
                Proveedor = new CategoryFilter() { ItemsFilter = proveedorTuple.Item1, CanFilter = marcaTuple.Item2 },
                Subrubro = new CategoryFilter() { ItemsFilter = subrubroTuple.Item1, CanFilter = marcaTuple.Item2 },
                //Vademecum = new CategoryFilter() { ItemsFilter = vademecumTuple.Item1, CanFilter = marcaTuple.Item2 },
                //Tipo = new CategoryFilter() { ItemsFilter = tipoTuple.Item1, CanFilter = marcaTuple.Item2 },
                //Laboratorio = new CategoryFilter() { ItemsFilter = laboratorioTuple.Item1, CanFilter = marcaTuple.Item2 },
                //Categoria = new CategoryFilter() { ItemsFilter = categoriaTuple.Item1, CanFilter = marcaTuple.Item2 },
                //Droga = new CategoryFilter() { ItemsFilter = drogaTuple.Item1, CanFilter = marcaTuple.Item2 },
                ////Accion = new CategoryFilter() { ItemsFilter = accionTuple.Item1, CanFilter = marcaTuple.Item2 },
                //Especie = new CategoryFilter() { ItemsFilter = especieTuple.Item1, CanFilter = marcaTuple.Item2 },
                //Via_Administracion = new CategoryFilter() { ItemsFilter = viaAdministracionTuple.Item1, CanFilter = marcaTuple.Item2 }
            };
        }

        private async Task<Tuple<List<ItemFilter>, bool>> GetItemsFilters(List<ProductsSyncDTO> products, List<string> values, ProductFieldTypeEnum fieldType)
        {
            var itemFilters = new List<ItemFilter>();
            var newProducts = new List<ProductsSyncDTO>();

            Parallel.ForEach(values, value =>
            {
                var filterProducts = new List<ProductsSyncDTO>();

                switch (fieldType)
                {
                    case ProductFieldTypeEnum.Marca: filterProducts = products.Where(p => p.MARCA == value).ToList(); break;
                    case ProductFieldTypeEnum.Proveedor: filterProducts = products.Where(p => p.PROVEEDOR == value).ToList(); break;
                    case ProductFieldTypeEnum.Subrubro: filterProducts = products.Where(p => p.SUBRUBRO == value).ToList(); break;
                    //case ProductFieldTypeEnum.Vademecum: filterProducts = products.Where(p => p.VADEMECUM == value).ToList(); break;
                    //case ProductFieldTypeEnum.Tipo: filterProducts = products.Where(p => p.TIPO == value).ToList(); break;
                    //case ProductFieldTypeEnum.Laboratorio: filterProducts = products.Where(p => p.LABORATORIO == value).ToList(); break;
                    //case ProductFieldTypeEnum.Categoria: filterProducts = products.Where(p => p.CATEGORIA == value).ToList(); break;
                    //case ProductFieldTypeEnum.Droga: filterProducts = products.Where(p => p.DROGA == value).ToList(); break;
                    //case ProductFieldTypeEnum.Accion: filterProducts = products.Where(p => p.ACCION == value).ToList(); break;
                    //case ProductFieldTypeEnum.Especie: filterProducts = products.Where(p => p.ESPECIE == value).ToList(); break;
                    //case ProductFieldTypeEnum.ViaAdministracion: filterProducts = products.Where(p => p.VIA_ADMINISTRACION == value).ToList(); break;
                }

                itemFilters.Add(new ItemFilter()
                {
                    Value = value,
                    Quantity = filterProducts.Count()
                });
            });
            if (itemFilters.Any(i => i == null))
                itemFilters = itemFilters.Where(i => i != null).ToList();
            return Tuple.Create(itemFilters.OrderBy(i => i.Value).ToList(), itemFilters.Count > 0);
        }

        public async Task<List<ProductsSyncResponseDTO>> GetProductsWithUpdatePrices(List<ProductsSyncDTO> products, bool noLogged = false)
        {
            List<ProductsSyncResponseDTO> newProducts = new List<ProductsSyncResponseDTO>();
            foreach (var product in products)
            {
                object price = 0;
                try
                {
                    price = product.GetType().GetProperty(noLogged ? NoLoggedColumn : product.COLUMNA_SELECCIONADA).GetValue(product, null);
                }
                catch { }
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
                    ROW_COUNT = product.ROW_COUNT,
                    CONDICION = product.CONDICION,
                    PRECIO = price?.ToString(),
                    PRECIO_ESP = product.PRECIO_NL,
                    PRECIO_BASE = product.PRECIO,
                    LOGGED = noLogged ? false : true
                });
            }
            return newProducts;
        }

        private string GetConditionFilter(List<string> conditions)
        {
            string where = string.Empty;
            if (conditions != null)
            {
                if (conditions.Count == 2)
                    where = "AND (condition.CODCONDI IN ('CCM', 'CCB'))";
                else if (conditions.Count == 1) where = $"AND (condition.CODCONDI = '{conditions.First()}')";
            }
            return where;
        }
        #endregion
    }
}
