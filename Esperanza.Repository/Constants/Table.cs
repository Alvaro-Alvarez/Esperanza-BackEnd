namespace Esperanza.Repository.Constants
{
    public static class Table
    {
        // Master Tables
        public static readonly string DocumentType = "DocumentType";
        public static readonly string Sex = "Sex";
        public static readonly string Country = "Country";
        public static readonly string City = "City";
        public static readonly string Neighborhood = "Neighborhood";
        public static readonly string UserRole = "UserRole";
        public static readonly string Category = "Category";
        public static readonly string Kind = "Kind";
        public static readonly string Line = "Line";
        public static readonly string OrderStatus = "OrderStatus";
        public static readonly string List = "List";
        public static readonly string SupplierItem = "SupplierItem";
        public static readonly string SubCategory = "SubCategory";
        public static readonly string Vademecum = "Vademecum";
        public static readonly string Laboratory = "Laboratory";

        public static readonly string PropductSync = "PropductSync";
        public static readonly string CustomerSync = "CustomerSync";
        public static readonly string CustomerConditionSync = "CustomerConditionSync";
        public static readonly string PriceListSync = "PriceListSync";
        public static readonly string TransportSync = "TransportSync";
        // Principal Tables
        public static readonly string Phone = "Phone";
        public static readonly string Address = "Address";
        public static readonly string PrincipalImage = "PrincipalImage";
        public static readonly string Product = "Product";
        public static readonly string GalleryImage = "GalleryImage";
        public static readonly string Person = "Person";
        public static readonly string AppUser = "AppUser";
        public static readonly string ProductsOrder = "ProductsOrder";
        public static readonly string UserProduct = "UserProduct";

        public static readonly string UpSelling = "UpSelling";
        public static readonly string CrossSelling = "CrossSelling";
        // Intermediate Tables
        public static readonly string OrderProduct = "OrderProduct";
        public static readonly string AddressPerson = "AddressPerson";
        public static readonly string ProductCategory = "ProductCategory";
        public static readonly string ProductKind = "ProductKind";
        public static readonly string ProductLine = "ProductLine";
        public static readonly string ProductUpSelling = "ProductUpSelling";
        public static readonly string ProductCrossSelling = "ProductCrossSelling";
    }
}
