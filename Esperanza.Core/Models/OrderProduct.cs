using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Models
{
    public class OrderProduct
    {
        public Guid OrderGuid { get; set; }
        public Guid ProductGuid { get; set; }
        public int Amount { get; set; }
        public decimal TotalPracieOfProducts { get; set; }
    }

    public class AddressPerson
    {
        public Guid PersonGuid { get; set; }
        public Guid AddressGuid { get; set; }
    }

    public class ProductCategory
    {
        public Guid ProductGuid { get; set; }
        public Guid CategoryGuid { get; set; }
    }

    public class ProductKind
    {
        public Guid ProductGuid { get; set; }
        public Guid KindGuid { get; set; }
    }

    public class ProductLine
    {
        public Guid ProductGuid { get; set; }
        public Guid LineGuid { get; set; }
    }
}
