using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class Product : Entity
    {
        public Product()
        {
            GalleryImages = new List<GalleryImage>();
            Categories = new List<Category>();
            Kinds = new List<Kind>();
            Lines = new List<Line>();
        }

        public Guid? PrincipalImageGuid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Stock { get; set; }
        public int? MinimumStock { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? Brand { get; set; }
        public string? BasProductCode { get; set; }
        public string? MainComponent { get; set; }
        public string? Drug { get; set; }
        public string? Action { get; set; }
        public string? Presentation { get; set; }
        public string? RoutesOfAdministration { get; set; }
        public string? MilkWithdrawal { get; set; }
        public string? MeatRecall { get; set; }
        public bool? Discontinued { get; set; }
        public bool? MissingInformation { get; set; }
        public bool? MissingFoto { get; set; }
        public string? OBS { get; set; }
        public Guid? CrossSellingGuid { get; set; }
        public Guid? UpSellingGuid { get; set; }
        public Guid? VademecumGuid { get; set; }
        public Guid? SubCategoryGuid { get; set; }
        public Guid? ListGuid { get; set; }
        public Guid? SupplierItemGuid { get; set; }
        public Guid? LaboratoryGuid { get; set; }


        [Description("ignore")]
        public List<Guid>? CategoryGuids { get; set; }

        [Description("ignore")]
        public List<Guid>? KindGuids { get; set; }

        [Description("ignore")]
        public List<Guid>? LineGuids { get; set; }


        [Description("ignore")]
        public List<Category>? Categories { get; set; }

        [Description("ignore")]
        public List<Kind>? Kinds { get; set; }

        [Description("ignore")]
        public List<Line>? Lines { get; set; }

        [Description("ignore")]
        public List<GalleryImage>? GalleryImages { get; set; }

        [Description("ignore")]
        public CrossSelling? CrossSelling { get; set; }

        [Description("ignore")]
        public UpSelling? UpSelling { get; set; }

        [Description("ignore")]
        public PrincipalImage? PrincipalImage { get; set; }

        // TODO: Fijaste si va a ser de muchos a muchos, ver como llega en el response
        [Description("ignore")]
        public Vademecum? Vademecum { get; set; }

        [Description("ignore")]
        public SubCategory? SubCategory { get; set; }

        [Description("ignore")]
        public List? List { get; set; }

        [Description("ignore")]
        public SupplierItem? SupplierItem { get; set; }


        //[Description("ignore")]
        //public decimal? TotalPrice
        //{
        //    get
        //    {
        //        return (UnitPrice.Value * Stock.Value);
        //    }
        //}
        //[Description("ignore")]
        //public static string GetAllLight
        //{
        //    get
        //    {
        //        return @"SELECT * FROM Product WHERE Deleted = 0";
        //    }
        //}

        [Description("ignore")]
        public static string GetAllLight
        {
            get
            {
                return @"SELECT * FROM Product p
                        LEFT JOIN PrincipalImage pimg ON p.PrincipalImageGuid = pimg.Guid
                        WHERE p.Deleted = 0";
            }
        }

        [Description("ignore")]
        public static string GetAllFull
        {
            get
            {
                return @"SELECT * FROM Product p
                        LEFT JOIN PrincipalImage pimg ON p.PrincipalImageGuid = pimg.Guid
                        LEFT JOIN Vademecum v ON p.VademecumGuid = v.Guid
                        LEFT JOIN SubCategory sc ON p.SubCategoryGuid = sc.Guid
                        LEFT JOIN List l ON p.ListGuid = l.Guid
                        LEFT JOIN SupplierItem si ON p.SupplierItemGuid = si.Guid
                        WHERE p.Deleted = 0";
            }
        }

        [Description("ignore")]
        public static string GetById
        {
            get
            {
                return @"SELECT * FROM Product p
                        LEFT JOIN PrincipalImage pimg ON p.PrincipalImageGuid = pimg.Guid
                        LEFT JOIN Vademecum v ON p.VademecumGuid = v.Guid
                        LEFT JOIN SubCategory sc ON p.SubCategoryGuid = sc.Guid
                        LEFT JOIN List l ON p.ListGuid = l.Guid
                        LEFT JOIN SupplierItem si ON p.SupplierItemGuid = si.Guid
                        WHERE p.Deleted = 0 AND p.Guid = @Guid";
            }
        }

        [Description("ignore")]
        public static string GetByIdSync
        {
            get
            {
                return @"SELECT DISTINCT 
                        product.CODIGO,
                        product.CBP,
                        product.MARCA,
                        product.PROVEEDOR,
                        product.SUBRUBRO,
                        product.VADEMECUM,
                        product.ALTA,
                        product.TIPO,
                        product.LABORATORIO,
                        product.CATEGORIA,
                        product.LINEA_BAL,
                        product.NOMBRE,
                        product.DROGA,
                        product.ACCION,
                        product.DESCRIPCION,
                        product.ESPECIE,
                        product.VIA_ADMINISTRACION,
                        product.PRESENTACION,
                        product.RETIRO_LECHE,
                        product.RETIRO_CARNE,
                        product.DISCONTINUADO,
                        product.FALTANTE_INFO,
                        product.FALTANTE_FOTO,
                        product.OBS,
                        product.FECHAREG,
                        product.ENLACE AS FOTO,
                        condition.COLUMNA AS COLUMNA_SELECCIONADA,
                        priceList.DESCRIPCION AS DESCRIPCION_LISTA,
                        priceList.PRECIO,
                        priceList.PRECIO_A,
                        priceList.PRECIO_B,
                        priceList.PRECIO_C,
                        priceList.PRECIO_D,
                        priceList.PRECIO_E,
                        priceList.PRECIO_F,
                        priceList.PRECIO_G,
                        priceList.PRECIO_H,
                        priceList.PRECIO_I,
                        priceList.PRECIO_J,
                        priceList.PRECIO_K,
                        priceList.PRECIO_L,
                        priceList.PRECIO_M,
                        priceList.PRECIO_N,
                        priceList.PRECIO_O,
                        priceList.PRECIO_NL,
                        condition.CODCONDI AS CONDICION
                        FROM CustomerConditionSync condition
                        INNER JOIN PriceListSync priceList ON priceList.CODLIS = condition.CODLIS
                        INNER JOIN PropductSync product ON product.CODIGO = priceList.CODITM
                        WHERE product.Deleted = 0 AND product.ACTIVO = 1 AND product.CODIGO = @Cod;";
            }
        }

        [Description("ignore")]
        public static string Pagination
        {
            get
            {
                // TODO: VER COMO MEJORAR
                return "OFFSET @Start ROWS FETCH NEXT 20 ROWS ONLY";
                //return "OFFSET @Start ROWS FETCH NEXT @End ROWS ONLY";
            }
        }

        [Description("ignore")]
        public static string GetAllWithPagination
        {
            get
            {
                return $"{GetAllFull} ORDER BY p.Name {Pagination}";
            }
        }

        [Description("ignore")]
        public static string GetCount
        {
            get
            {
                return @"SELECT COUNT(*) FROM Product WHERE Deleted = 0;";
            }
        }









        [Description("ignore")]
        public static string GetAllFullSync
        {
            get
            {
                return @"SELECT DISTINCT 
                        product.CODIGO,
                        product.CBP,
                        product.MARCA,
                        product.PROVEEDOR,
                        product.SUBRUBRO,
                        product.VADEMECUM,
                        product.ALTA,
                        product.TIPO,
                        product.LABORATORIO,
                        product.CATEGORIA,
                        product.LINEA_BAL,
                        product.NOMBRE,
                        product.DROGA,
                        product.ACCION,
                        product.DESCRIPCION,
                        product.ESPECIE,
                        product.VIA_ADMINISTRACION,
                        product.PRESENTACION,
                        product.RETIRO_LECHE,
                        product.RETIRO_CARNE,
                        product.DISCONTINUADO,
                        product.FALTANTE_INFO,
                        product.FALTANTE_FOTO,
                        product.OBS,
                        product.FECHAREG,
                        product.ENLACE AS FOTO,
                        condition.COLUMNA AS COLUMNA_SELECCIONADA,
                        priceList.DESCRIPCION AS DESCRIPCION_LISTA,
                        priceList.PRECIO,
                        priceList.PRECIO_A,
                        priceList.PRECIO_B,
                        priceList.PRECIO_C,
                        priceList.PRECIO_D,
                        priceList.PRECIO_E,
                        priceList.PRECIO_F,
                        priceList.PRECIO_G,
                        priceList.PRECIO_H,
                        priceList.PRECIO_I,
                        priceList.PRECIO_J,
                        priceList.PRECIO_K,
                        priceList.PRECIO_L,
                        priceList.PRECIO_M,
                        priceList.PRECIO_N,
                        priceList.PRECIO_O,
                        priceList.PRECIO_NL,
                        condition.CODCONDI AS CONDICION
                        FROM CustomerConditionSync condition
                        INNER JOIN PriceListSync priceList ON priceList.CODLIS = condition.CODLIS
                        INNER JOIN PropductSync product ON product.CODIGO = priceList.CODITM
                        WHERE CODCTACTE = @ClientCode AND product.Deleted = 0 AND product.ACTIVO = 1 
                        ORDER BY product.NOMBRE " + Pagination;
            }
        }

        [Description("ignore")]
        public static string GetAllFullCountSync
        {
            get
            {
                return @"SELECT DISTINCT COUNT(*)
                        FROM CustomerConditionSync condition
                        INNER JOIN PriceListSync priceList ON priceList.CODLIS = condition.CODLIS
                        INNER JOIN PropductSync product ON product.CODIGO = priceList.CODITM
                        WHERE CODCTACTE = @ClientCode AND product.Deleted = 0 AND product.ACTIVO = 1;";
            }
        }


        [Description("ignore")]
        public static string GetAllFullNoLoggedSync
        {
            get
            {
                return @"SELECT DISTINCT 
                        product.CODIGO,
                        product.CBP,
                        product.MARCA,
                        product.PROVEEDOR,
                        product.SUBRUBRO,
                        product.VADEMECUM,
                        product.ALTA,
                        product.TIPO,
                        product.LABORATORIO,
                        product.CATEGORIA,
                        product.LINEA_BAL,
                        product.NOMBRE,
                        product.DROGA,
                        product.ACCION,
                        product.DESCRIPCION,
                        product.ESPECIE,
                        product.VIA_ADMINISTRACION,
                        product.PRESENTACION,
                        product.RETIRO_LECHE,
                        product.RETIRO_CARNE,
                        product.DISCONTINUADO,
                        product.FALTANTE_INFO,
                        product.FALTANTE_FOTO,
                        product.OBS,
                        product.FECHAREG,
                        product.ENLACE AS FOTO,
                        condition.COLUMNA AS COLUMNA_SELECCIONADA,
                        priceList.DESCRIPCION AS DESCRIPCION_LISTA,
                        priceList.PRECIO,
                        priceList.PRECIO_A,
                        priceList.PRECIO_B,
                        priceList.PRECIO_C,
                        priceList.PRECIO_D,
                        priceList.PRECIO_E,
                        priceList.PRECIO_F,
                        priceList.PRECIO_G,
                        priceList.PRECIO_H,
                        priceList.PRECIO_I,
                        priceList.PRECIO_J,
                        priceList.PRECIO_K,
                        priceList.PRECIO_L,
                        priceList.PRECIO_M,
                        priceList.PRECIO_N,
                        priceList.PRECIO_O,
                        priceList.PRECIO_NL,
                        condition.CODCONDI AS CONDICION
                        FROM CustomerConditionSync condition
                        INNER JOIN PriceListSync priceList ON priceList.CODLIS = condition.CODLIS
                        INNER JOIN PropductSync product ON product.CODIGO = priceList.CODITM
                        WHERE product.Deleted = 0 AND product.ACTIVO = 1 
                        ORDER BY product.NOMBRE " + Pagination;
            }
        }

        [Description("ignore")]
        public static string GetAllFullCountNoLoggedSync
        {
            get
            {
                return @"SELECT DISTINCT COUNT(*)
                        FROM CustomerConditionSync condition
                        INNER JOIN PriceListSync priceList ON priceList.CODLIS = condition.CODLIS
                        INNER JOIN PropductSync product ON product.CODIGO = priceList.CODITM
                        WHERE product.Deleted = 0 AND product.ACTIVO = 1;";
            }
        }
    }
}
