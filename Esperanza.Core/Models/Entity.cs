using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class Entity
    {
        [Description("key")]
        public Guid? Guid { get; set; }
        public bool? Deleted { get; set; } = false;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
