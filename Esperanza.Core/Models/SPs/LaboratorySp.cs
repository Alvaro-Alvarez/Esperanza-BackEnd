namespace Esperanza.Core.Models.SPs
{
    public class LaboratorySp
    {
        public string? LaboratoryTitle { get; set; }
        public string? LaboratoryDescription { get; set; }
        public Guid? IdImage { get; set; }
        public Guid? Guid { get; set; }
        public string? Base64Image { get; set; }
        public int? Order{ get; set; }
        public string? Rows { get; set; }
    }
}
