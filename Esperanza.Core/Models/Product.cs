using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class Product : Entity
    {

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
                        priceList.PRECIO_SP,
                        priceList.PRECIO_NL,
                        priceList.PRECIO_NL1,
                        condition.CODCONDI AS CONDICION
                        FROM CustomerConditionSync condition
                        INNER JOIN PriceListSync priceList ON priceList.CODLIS = condition.CODLIS
                        INNER JOIN PropductSync product ON product.CODIGO = priceList.CODITM
                        WHERE CODCTACTE = @ClientCode AND product.Deleted = 0 AND product.ACTIVO = 1 AND product.CODIGO = @Cod;";
            }
        }

        [Description("ignore")]
        public static string GetByIdNoLoggedSync
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
                        priceList.PRECIO_SP,
                        priceList.PRECIO_NL,
                        priceList.PRECIO_NL1,
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
                return "OFFSET @Start ROWS FETCH NEXT 10 ROWS ONLY";
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
                        priceList.PRECIO_SP,
                        priceList.PRECIO_NL,
                        priceList.PRECIO_NL1,
                        condition.CODCONDI AS CONDICION
                        FROM CustomerConditionSync condition
                        INNER JOIN PriceListSync priceList ON priceList.CODLIS = condition.CODLIS
                        INNER JOIN PropductSync product ON product.CODIGO = priceList.CODITM
                        WHERE CODCTACTE = @ClientCode AND product.Deleted = 0 AND product.ACTIVO = 1
                        AND (product.NOMBRE LIKE '%@Search%' OR product.MARCA LIKE '%@Search%' OR product.LABORATORIO LIKE '%@Search%' OR product.ACCION LIKE '%@Search%' OR product.ESPECIE LIKE '%@Search%' OR product.VIA_ADMINISTRACION LIKE '%@Search%' OR product.DROGA LIKE '%@Search%')
                        AND (@Marca IS NULL OR product.MARCA IN @Marca)
                        AND (@Proveedor IS NULL OR product.PROVEEDOR IN @Proveedor)
                        AND (@Subrubro IS NULL OR product.SUBRUBRO IN @Subrubro)
                        AND (@Vademecum IS NULL OR product.VADEMECUM IN @Vademecum)
                        AND (@Tipo IS NULL OR product.TIPO IN @Tipo)
                        AND (@Laboratorio IS NULL OR product.LABORATORIO IN @Laboratorio)
                        AND (@Categoria IS NULL OR product.CATEGORIA IN @Categoria)
                        AND (@Droga IS NULL OR product.DROGA IN @Droga)
                        AND (@Accion IS NULL OR product.ACCION IN @Accion)
                        AND (@Especie IS NULL OR product.ESPECIE IN @Especie)
                        AND (@ViaAdministracion IS NULL OR product.VIA_ADMINISTRACION IN @ViaAdministracion)
                        @ConditionFilter
                        ORDER BY product.NOMBRE " + Pagination;
            }
        }

        [Description("ignore")]
        public static string GetAllFullSyncNoPagination
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
                        priceList.PRECIO_SP,
                        priceList.PRECIO_NL,
                        priceList.PRECIO_NL1,
                        condition.CODCONDI AS CONDICION
                        FROM CustomerConditionSync condition
                        INNER JOIN PriceListSync priceList ON priceList.CODLIS = condition.CODLIS
                        INNER JOIN PropductSync product ON product.CODIGO = priceList.CODITM
                        WHERE CODCTACTE = @ClientCode AND product.Deleted = 0 AND product.ACTIVO = 1
                        AND (product.NOMBRE LIKE '%@Search%' OR product.MARCA LIKE '%@Search%' OR product.LABORATORIO LIKE '%@Search%' OR product.ACCION LIKE '%@Search%' OR product.ESPECIE LIKE '%@Search%' OR product.VIA_ADMINISTRACION LIKE '%@Search%' OR product.DROGA LIKE '%@Search%')
                        AND (@Marca IS NULL OR product.MARCA IN @Marca)
                        AND (@Proveedor IS NULL OR product.PROVEEDOR IN @Proveedor)
                        AND (@Subrubro IS NULL OR product.SUBRUBRO IN @Subrubro)
                        AND (@Vademecum IS NULL OR product.VADEMECUM IN @Vademecum)
                        AND (@Tipo IS NULL OR product.TIPO IN @Tipo)
                        AND (@Laboratorio IS NULL OR product.LABORATORIO IN @Laboratorio)
                        AND (@Categoria IS NULL OR product.CATEGORIA IN @Categoria)
                        AND (@Droga IS NULL OR product.DROGA IN @Droga)
                        AND (@Accion IS NULL OR product.ACCION IN @Accion)
                        AND (@Especie IS NULL OR product.ESPECIE IN @Especie)
                        AND (@ViaAdministracion IS NULL OR product.VIA_ADMINISTRACION IN @ViaAdministracion)
                        @ConditionFilter
                        ORDER BY product.NOMBRE";
            }
        }

        [Description("ignore")]
        public static string GetAllRecommended
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
                        priceList.PRECIO_SP,
                        priceList.PRECIO_NL,
                        priceList.PRECIO_NL1,
                        condition.CODCONDI AS CONDICION
                        FROM CustomerConditionSync condition
                        INNER JOIN PriceListSync priceList ON priceList.CODLIS = condition.CODLIS
                        INNER JOIN PropductSync product ON product.CODIGO = priceList.CODITM
                        WHERE product.Deleted = 0 AND product.ACTIVO = 1 AND product.CODIGO IN @ProductCodes AND condition.CODCTACTE = @ClientCode
                        ORDER BY product.NOMBRE";
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
                        WHERE CODCTACTE = @ClientCode AND product.Deleted = 0 AND product.ACTIVO = 1
                        AND (product.NOMBRE LIKE '%@Search%' OR product.MARCA LIKE '%@Search%' OR product.LABORATORIO LIKE '%@Search%' OR product.ACCION LIKE '%@Search%' OR product.ESPECIE LIKE '%@Search%' OR product.VIA_ADMINISTRACION LIKE '%@Search%' OR product.DROGA LIKE '%@Search%')
                        AND (@Marca IS NULL OR product.MARCA IN @Marca)
                        AND (@Proveedor IS NULL OR product.PROVEEDOR IN @Proveedor)
                        AND (@Subrubro IS NULL OR product.SUBRUBRO IN @Subrubro)
                        AND (@Vademecum IS NULL OR product.VADEMECUM IN @Vademecum)
                        AND (@Tipo IS NULL OR product.TIPO IN @Tipo)
                        AND (@Laboratorio IS NULL OR product.LABORATORIO IN @Laboratorio)
                        AND (@Categoria IS NULL OR product.CATEGORIA IN @Categoria)
                        AND (@Droga IS NULL OR product.DROGA IN @Droga)
                        AND (@Accion IS NULL OR product.ACCION IN @Accion)
                        AND (@Especie IS NULL OR product.ESPECIE IN @Especie)
                        AND (@ViaAdministracion IS NULL OR product.VIA_ADMINISTRACION IN @ViaAdministracion)
                        @ConditionFilter";
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
                        priceList.PRECIO_SP,
                        priceList.PRECIO_NL,
                        priceList.PRECIO_NL1,
                        condition.CODCONDI AS CONDICION
                        FROM CustomerConditionSync condition
                        INNER JOIN PriceListSync priceList ON priceList.CODLIS = condition.CODLIS
                        INNER JOIN PropductSync product ON product.CODIGO = priceList.CODITM
                        WHERE product.Deleted = 0 AND product.ACTIVO = 1 AND condition.CODCONDI = 'CCM' AND condition.COLUMNA = 'PRECIO_A'
                        AND (product.NOMBRE LIKE '%@Search%' OR product.MARCA LIKE '%@Search%' OR product.LABORATORIO LIKE '%@Search%' OR product.ACCION LIKE '%@Search%' OR product.ESPECIE LIKE '%@Search%' OR product.VIA_ADMINISTRACION LIKE '%@Search%' OR product.DROGA LIKE '%@Search%')
                        AND (@Marca IS NULL OR product.MARCA IN @Marca)
                        AND (@Proveedor IS NULL OR product.PROVEEDOR IN @Proveedor)
                        AND (@Subrubro IS NULL OR product.SUBRUBRO IN @Subrubro)
                        AND (@Vademecum IS NULL OR product.VADEMECUM IN @Vademecum)
                        AND (@Tipo IS NULL OR product.TIPO IN @Tipo)
                        AND (@Laboratorio IS NULL OR product.LABORATORIO IN @Laboratorio)
                        AND (@Categoria IS NULL OR product.CATEGORIA IN @Categoria)
                        AND (@Droga IS NULL OR product.DROGA IN @Droga)
                        AND (@Accion IS NULL OR product.ACCION IN @Accion)
                        AND (@Especie IS NULL OR product.ESPECIE IN @Especie)
                        AND (@ViaAdministracion IS NULL OR product.VIA_ADMINISTRACION IN @ViaAdministracion)
                        @ConditionFilter
                        ORDER BY product.NOMBRE " + Pagination;
            }
        }

        [Description("ignore")]
        public static string GetAllFullNoLoggedSyncNoPagination
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
                        priceList.PRECIO_SP,
                        priceList.PRECIO_NL,
                        priceList.PRECIO_NL1,
                        condition.CODCONDI AS CONDICION
                        FROM CustomerConditionSync condition
                        INNER JOIN PriceListSync priceList ON priceList.CODLIS = condition.CODLIS
                        INNER JOIN PropductSync product ON product.CODIGO = priceList.CODITM
                        WHERE product.Deleted = 0 AND product.ACTIVO = 1 AND condition.CODCONDI = 'CCM' AND condition.COLUMNA = 'PRECIO_A'
                        AND (product.NOMBRE LIKE '%@Search%' OR product.MARCA LIKE '%@Search%' OR product.LABORATORIO LIKE '%@Search%' OR product.ACCION LIKE '%@Search%' OR product.ESPECIE LIKE '%@Search%' OR product.VIA_ADMINISTRACION LIKE '%@Search%' OR product.DROGA LIKE '%@Search%')
                        AND (@Marca IS NULL OR product.MARCA IN @Marca)
                        AND (@Proveedor IS NULL OR product.PROVEEDOR IN @Proveedor)
                        AND (@Subrubro IS NULL OR product.SUBRUBRO IN @Subrubro)
                        AND (@Vademecum IS NULL OR product.VADEMECUM IN @Vademecum)
                        AND (@Tipo IS NULL OR product.TIPO IN @Tipo)
                        AND (@Laboratorio IS NULL OR product.LABORATORIO IN @Laboratorio)
                        AND (@Categoria IS NULL OR product.CATEGORIA IN @Categoria)
                        AND (@Droga IS NULL OR product.DROGA IN @Droga)
                        AND (@Accion IS NULL OR product.ACCION IN @Accion)
                        AND (@Especie IS NULL OR product.ESPECIE IN @Especie)
                        AND (@ViaAdministracion IS NULL OR product.VIA_ADMINISTRACION IN @ViaAdministracion)
                        @ConditionFilter
                        ORDER BY product.NOMBRE";
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
                        WHERE product.Deleted = 0 AND product.ACTIVO = 1
                        AND (product.NOMBRE LIKE '%@Search%' OR product.MARCA LIKE '%@Search%' OR product.LABORATORIO LIKE '%@Search%' OR product.ACCION LIKE '%@Search%' OR product.ESPECIE LIKE '%@Search%' OR product.VIA_ADMINISTRACION LIKE '%@Search%' OR product.DROGA LIKE '%@Search%')
                        AND (@Marca IS NULL OR product.MARCA IN @Marca)
                        AND (@Proveedor IS NULL OR product.PROVEEDOR IN @Proveedor)
                        AND (@Subrubro IS NULL OR product.SUBRUBRO IN @Subrubro)
                        AND (@Vademecum IS NULL OR product.VADEMECUM IN @Vademecum)
                        AND (@Tipo IS NULL OR product.TIPO IN @Tipo)
                        AND (@Laboratorio IS NULL OR product.LABORATORIO IN @Laboratorio)
                        AND (@Categoria IS NULL OR product.CATEGORIA IN @Categoria)
                        AND (@Droga IS NULL OR product.DROGA IN @Droga)
                        AND (@Accion IS NULL OR product.ACCION IN @Accion)
                        AND (@Especie IS NULL OR product.ESPECIE IN @Especie)
                        AND (@ViaAdministracion IS NULL OR product.VIA_ADMINISTRACION IN @ViaAdministracion)
                        @ConditionFilter";
            }
        }

        [Description("ignore")]
        public static string GetImagesByCodes
        {
            get
            {
                return @"select distinct ENLACE from PropductSync where CODIGO in @Codes;";
            }
        }
    }
}
