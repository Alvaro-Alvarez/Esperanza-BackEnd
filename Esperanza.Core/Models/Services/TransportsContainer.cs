namespace Esperanza.Core.Models.Services
{
    public class TransportsContainer
    {
        public List<List<Transports>> recordsets { get; set; }
        public List<Transports> recordset { get; set; }
        public List<int> rowsAffected { get; set; }
    }

    public class Transports
    {
        public string coditm { get; set; }
        public string DESCRIPCION { get; set; }
        public string codlis { get; set; }
        public double? precio { get; set; }
        public DateTime vigencia { get; set; }
    }
}
