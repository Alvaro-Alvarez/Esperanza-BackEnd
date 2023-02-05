namespace Esperanza.Core.Models
{
    public class OrderItems
    {
        public Order? OrderCcm { get; set; }
        public Order? OrderCcb { get; set; }
    }

    public class Order
    {
        public OrderSale? PedidoVenta { get; set; }
    }

    public class OrderSale
    {
        public string? Cliente { get; set; }
        public string? Comprobante { get; set; }
        public string? Concepto { get; set; }
        public string? CondicionVentaCompra { get; set; }
        public string? Deposito { get; set; }
        public string? Empresa { get; set; }
        public string? Fecha { get; set; }
        public string? FechaExpiracion { get; set; }
        public string? ListaPrecios { get; set; }
        public string? MetodoPago { get; set; }
        public string? Numero { get; set; }
        public string? Prefijo { get; set; }
        public string? Sucursal { get; set; }
        public string? Total { get; set; }
        public string? TotalGravado { get; set; }
        public string? TotalImpuestosInternos { get; set; }
        public string? TotalIva { get; set; }
        public string? TotalPercepcionGanancias { get; set; }
        public string? TotalPercepcionIngBr { get; set; }
        public string? TotalPercepcionIva { get; set; }
        public string? Transportista { get; set; }
        public string? VendedoroCobrador { get; set; }
        public List<Item>? Items { get; set; }
    }

    public class Item
    {
        public string? CantidadPrimeraUnidad { get; set; }
        public string? CodigoItem { get; set; }
        public string? FechaEntrega { get; set; }
        public string? ImporteGravado { get; set; }
        public string? ImporteImpuestoInterno { get; set; }
        public string? ImporteIva { get; set; }
        public string? ImporteIvaNoInscripto { get; set; }
        public string? ImportePercepcionGanancias { get; set; }
        public string? ImportePercepcionIngBr { get; set; }
        public string? ImportePercepcionIva { get; set; }
        public string? ImporteTotal { get; set; }
        public string? NumeroUnidadMedida { get; set; }
        public string? ObservacionItem { get; set; }
        public string? PendienteRemitirFacturar { get; set; }
        public string? PorcentajeBonificacion { get; set; }
        public string? PorcentajeComisionCobranzas { get; set; }
        public string? PorcentajeComisionVentas { get; set; }
        public string? PorcentajeSegundaBonificacion { get; set; }
        public string? PrecioUnitario { get; set; }
        public string? SecuenciaDetalle { get; set; }
        public string? TasaImpuestoInterno { get; set; }
        public string? TasaIva { get; set; }
        public string? TasaIvaNoInscripto { get; set; }
    }
}
