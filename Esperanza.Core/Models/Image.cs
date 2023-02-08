using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class Image : Entity
    {
        public string? FullName { get; set; }
        public string? Extension { get; set; }


        [Description("ignore")]
        public string? Base64Image { get; set; }
    }
}
