﻿using System.ComponentModel;

namespace Esperanza.Core.Models.Response
{
    public class ProductsResponse
    {
        public List<ProductsSyncResponseDTO> Products { get; set; }
        public ValuesToFilter ValuesToFilter { get; set; }
        public int Rows { get; set; }
    }

    public class ValuesToFilter
    {
        public CategoryFilter Marca { get; set; }
        public CategoryFilter Proveedor { get; set; }
        public CategoryFilter Subrubro { get; set; }
        public CategoryFilter Vademecum { get; set; }
        public CategoryFilter Tipo { get; set; }
        public CategoryFilter Laboratorio { get; set; }
        public CategoryFilter Categoria { get; set; }
        public CategoryFilter Droga { get; set; }
        //public CategoryFilter Accion { get; set; }
        public CategoryFilter Especie { get; set; }
        public CategoryFilter Via_Administracion { get; set; }
    }

    public class CategoryFilter
    {
        public CategoryFilter()
        {
            ItemsFilter = new List<ItemFilter>();
        }

        public List<ItemFilter> ItemsFilter { get; set; }
        public bool CanFilter { get; set; }
    }

    public class ItemFilter
    {
        public string Value { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductsSyncDTO
    {
        public string CODIGO { get; set; }
        public string CBP { get; set; }
        public string MARCA { get; set; }
        public string PROVEEDOR { get; set; }
        public string SUBRUBRO { get; set; }
        public string VADEMECUM { get; set; }
        public string ALTA { get; set; }
        public string TIPO { get; set; }
        public string LABORATORIO { get; set; }
        public string CATEGORIA { get; set; }
        public string LINEA_BAL { get; set; }
        public string NOMBRE { get; set; }
        public string DROGA { get; set; }
        public string ACCION { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESPECIE { get; set; }
        public string VIA_ADMINISTRACION { get; set; }
        public string PRESENTACION { get; set; }
        public string RETIRO_LECHE { get; set; }
        public string RETIRO_CARNE { get; set; }
        public string DISCONTINUADO { get; set; }
        public string FALTANTE_INFO { get; set; }
        public string FALTANTE_FOTO { get; set; }
        public string OBS { get; set; }
        public string FECHAREG { get; set; }
        public string FOTO { get; set; }
        public string COLUMNA_SELECCIONADA { get; set; }
        public string DESCRIPCION_LISTA { get; set; }
        public string PRECIO { get; set; }
        public string PRECIO_A { get; set; }
        public string PRECIO_B { get; set; }
        public string PRECIO_C { get; set; }
        public string PRECIO_D { get; set; }
        public string PRECIO_E { get; set; }
        public string PRECIO_F { get; set; }
        public string PRECIO_G { get; set; }
        public string PRECIO_H { get; set; }
        public string PRECIO_I { get; set; }
        public string PRECIO_J { get; set; }
        public string PRECIO_K { get; set; }
        public string PRECIO_L { get; set; }
        public string PRECIO_M { get; set; }
        public string PRECIO_N { get; set; }
        public string PRECIO_O { get; set; }
        public string PRECIO_SP { get; set; }
        public string PRECIO_NL { get; set; }
        public string PRECIO_NL1 { get; set; }
        public string CONDICION { get; set; }
        public int ROW_COUNT { get; set; }
    }

    public class ProductsSyncResponseDTO
    {
        public string CODIGO { get; set; }
        public string CBP { get; set; }
        public string MARCA { get; set; }
        public string PROVEEDOR { get; set; }
        public string SUBRUBRO { get; set; }
        public string VADEMECUM { get; set; }
        public string ALTA { get; set; }
        public string TIPO { get; set; }
        public string LABORATORIO { get; set; }
        public string CATEGORIA { get; set; }
        public string LINEA_BAL { get; set; }
        public string NOMBRE { get; set; }
        public string DROGA { get; set; }
        public string ACCION { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESPECIE { get; set; }
        public string VIA_ADMINISTRACION { get; set; }
        public string PRESENTACION { get; set; }
        public string RETIRO_LECHE { get; set; }
        public string RETIRO_CARNE { get; set; }
        public string DISCONTINUADO { get; set; }
        public string FALTANTE_INFO { get; set; }
        public string FALTANTE_FOTO { get; set; }
        public string OBS { get; set; }
        public string FECHAREG { get; set; }
        public string FOTO { get; set; }
        public string PRECIO { get; set; }
        public string PRECIO_ESP { get; set; }
        public string PRECIO_BASE { get; set; }
        public bool LOGGED { get; set; }
        public string CONDICION { get; set; }
        public int ROW_COUNT { get; set; }

        [Description("ignore")]
        public string? Semaphore { get; set; }
    }
}
