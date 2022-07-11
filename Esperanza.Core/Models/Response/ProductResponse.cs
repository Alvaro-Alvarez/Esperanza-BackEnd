namespace Esperanza.Core.Models.Response
{
    public class ProductResponse
    {
        public ProductResponse()
        {
            Alternativos = new List<object>();
            Presentaciones = new List<object>();
            Promociones = new List<object>();
        }

        public string Codigo { get; set; }
        public double Precio { get; set; }
        public long TasaIva { get; set; }
        public long Stock { get; set; }
        public string RequiereReceta { get; set; }
        public object Recurso { get; set; }
        public List<object> Alternativos { get; set; }
        public List<object> Presentaciones { get; set; }
        public Bonificaciones[] Bonificaciones { get; set; }
        public string TienePromociones { get; set; }
        public List<object> Promociones { get; set; }
    }

    public partial class Bonificaciones
    {
        public long CantidadDesde { get; set; }
        public double Porcentaje { get; set; }
    }
}
