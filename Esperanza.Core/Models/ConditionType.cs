namespace Esperanza.Core.Models
{
    public class ConditionType : Entity
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? PriceList { get; set; }
        public int? Order { get; set; }
    }
}
