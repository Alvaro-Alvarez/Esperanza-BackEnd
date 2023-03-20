namespace Esperanza.Core.Models.Request
{
    public class VademecumFilter : Pagination
    {
        public string? Accion { get; set; }
        public string? Especie { get; set; }
        public string? Administracion { get; set; }
        public string? Droga { get; set; }
        public List<string>? Condiciones { get; set; }

        public VademecumFilter()
        {
            Condiciones = new List<string>();
        }
    }
}
