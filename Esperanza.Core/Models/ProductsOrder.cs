using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Models
{
    public class ProductsOrder : Entity
    {
        public Guid UserGuid { get; set; }
        public Guid OrderStatusGuid { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
