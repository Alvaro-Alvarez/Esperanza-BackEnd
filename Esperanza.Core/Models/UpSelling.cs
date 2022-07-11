using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class UpSelling : Entity
    {
        public UpSelling()
        {
            Products = new List<Product>();
        }

        public bool? WithAlgorithm { get; set; }
        public bool? PriorityInAlgorithm { get; set; }
        public int? ProductsToShow { get; set; }

        [Description("ignore")]
        public List<Product>? Products { get; set; }
    }
}
