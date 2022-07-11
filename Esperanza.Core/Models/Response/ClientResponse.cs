namespace Esperanza.Core.Models.Response
{
    public class ClientResponse
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? NumeroIdentificacionImpositiva { get; set; }
        public string? CategoriaIva { get; set; }
        public string? CondicionVentaMedicamentos { get; set; }
        public string? DescripcionCondicionVentaMedicamentos { get; set; }
        public string? CondicionVentaBalanceado { get; set; }
        public string? DescripcionCondicionVentaBalanceado { get; set; }
        public double DeudaPorVencer { get; set; }
        public double DeudaVencida { get; set; }
        public string? Bloqueado { get; set; }
        public int Empresa { get; set; }
        public int Sucursal { get; set; }
        public string? Deposito { get; set; }
        public string? CodigoVendedor { get; set; }
        public string? NombreVendedor { get; set; }
        public string? EmailVendedor { get; set; }
        public string? TelefonoVendedor { get; set; }
        public int Prefijo { get; set; }
    }
}
