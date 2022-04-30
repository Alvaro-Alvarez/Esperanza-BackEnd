using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Models
{
    public class Product : Entity
    {
        public Guid PrincipalImageGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int MinimumStock { get; set; }
        public decimal UnitPrice { get; set; }
        public string Brand { get; set; }

        [Description("ignore")]
        public decimal TotalPrice
        {
            get
            {
                return (UnitPrice * Stock);
            }
        }
    }
}
