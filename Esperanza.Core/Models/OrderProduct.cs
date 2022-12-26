using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static string Insert
        {
            get
            {
                return @"INSERT INTO ProductCategory (ProductGuid, CategoryGuid) VALUES (@ProductGuid, @CategoryGuid)";
            }
        }

        public static string GetAllByProductId
        {
            get
            {
                return @"SELECT c.* FROM Category c
                        LEFT JOIN ProductCategory pc ON c.Guid = pc.CategoryGuid
                        WHERE pc.ProductGuid IN @ProductGuid;";
            }
        }
    }

    public class ProductKind
    {
        public Guid ProductGuid { get; set; }
        public Guid KindGuid { get; set; }

        [Description("ignore")]
        public static string Insert
        {
            get
            {
                return @"INSERT INTO ProductKind (ProductGuid, KindGuid) VALUES (@ProductGuid, @KindGuid)";
            }
        }

        public static string GetAllByProductId
        {
            get
            {
                return @"SELECT k.* FROM Kind k
                        LEFT JOIN ProductKind pk ON k.Guid = pk.KindGuid
                        WHERE pk.ProductGuid = @ProductGuid;";
            }
        }
    }

    public class ProductLine
    {
        public Guid ProductGuid { get; set; }
        public Guid LineGuid { get; set; }

        public static string Insert
        {
            get
            {
                return @"INSERT INTO ProductLine (ProductGuid, LineGuid) VALUES (@ProductGuid, @LineGuid)";
            }
        }

        public static string GetAllByProductId
        {
            get
            {
                return @"SELECT l.* FROM Line l
                        LEFT JOIN ProductLine pl ON l.Guid = pl.LineGuid
                        WHERE pl.ProductGuid IN @ProductGuid;";
            }
        }
    }

    public class ProductUpSelling
    {
        public Guid ProductGuid { get; set; }
        public Guid LineGuid { get; set; }
        public int? Order { get; set; }
    }

    public class ProductCrossSelling
    {
        public Guid ProductGuid { get; set; }
        public Guid LineGuid { get; set; }
        public int? Order { get; set; }
    }
}
