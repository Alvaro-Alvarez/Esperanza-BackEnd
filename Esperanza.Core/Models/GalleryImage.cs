using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class GalleryImage : Entity
    {
        public Guid? ProductGuid { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageName { get; set; }
        public string? FullName { get; set; }
        public string? Extension { get; set; }

        [Description("ignore")]
        public string? Base64Image { get; set; }
    }
}
