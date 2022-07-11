using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class Product : Entity
    {
        public Product()
        {
            GalleryImages = new List<GalleryImage>();
        }

        public Guid? PrincipalImageGuid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Stock { get; set; }
        public int? MinimumStock { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? Brand { get; set; }
        public string? BasProductCode { get; set; }
        public Guid? CrossSellingGuid { get; set; }
        public Guid? UpSellingGuid { get; set; }
        public Guid? VademecumGuid { get; set; }
        public Guid? SubCategoryGuid { get; set; }
        public Guid? ListGuid { get; set; }
        public Guid? SupplierItemGuid { get; set; }


        [Description("ignore")]
        public List<GalleryImage>? GalleryImages { get; set; }

        [Description("ignore")]
        public CrossSelling? CrossSelling { get; set; }

        [Description("ignore")]
        public UpSelling? UpSelling { get; set; }

        [Description("ignore")]
        public PrincipalImage? PrincipalImage { get; set; }

        // TODO: Fijaste si va a ser de muchos a muchos, ver como llega en el response
        [Description("ignore")]
        public Vademecum? Vademecum { get; set; }

        [Description("ignore")]
        public SubCategory? SubCategory { get; set; }

        [Description("ignore")]
        public List? List { get; set; }

        [Description("ignore")]
        public SupplierItem? SupplierItem { get; set; }


        [Description("ignore")]
        public decimal? TotalPrice
        {
            get
            {
                return (UnitPrice.Value * Stock.Value);
            }
        }

        [Description("ignore")]
        public static string GetAllFull
        {
            get
            {
                return @"SELECT * FROM Product p
                        LEFT JOIN PrincipalImage pimg ON p.PrincipalImageGuid = pimg.Guid
                        LEFT JOIN Vademecum v ON p.VademecumGuid = v.Guid
                        LEFT JOIN SubCategory sc ON p.SubCategoryGuid = sc.Guid
                        LEFT JOIN List l ON p.ListGuid = l.Guid
                        LEFT JOIN SupplierItem si ON p.SupplierItemGuid = si.Guid
                        WHERE p.Deleted = 0";
            }
        }

        [Description("ignore")]
        public static string GetById
        {
            get
            {
                return @"SELECT * FROM Product p
                        LEFT JOIN PrincipalImage pimg ON p.PrincipalImageGuid = pimg.Guid
                        LEFT JOIN Vademecum v ON p.VademecumGuid = v.Guid
                        LEFT JOIN SubCategory sc ON p.SubCategoryGuid = sc.Guid
                        LEFT JOIN List l ON p.ListGuid = l.Guid
                        LEFT JOIN SupplierItem si ON p.SupplierItemGuid = si.Guid
                        WHERE p.Deleted = 0 AND p.Guid = @Guid";
            }
        }
    }
}
