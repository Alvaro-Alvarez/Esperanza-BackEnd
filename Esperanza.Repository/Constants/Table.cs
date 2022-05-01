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
        // Principal Tables
        public static readonly string Phone = "Phone";
        public static readonly string Address = "Address";
        public static readonly string PrincipalImage = "PrincipalImage";
        public static readonly string Product = "Product";
        public static readonly string GalleryImage = "GalleryImage";
        public static readonly string Person = "Person";
        public static readonly string AppUser = "AppUser";
        public static readonly string ProductsOrder = "ProductsOrder";
        // Intermediate Tables
        public static readonly string OrderProduct = "OrderProduct";
        public static readonly string AddressPerson = "AddressPerson";
        public static readonly string ProductCategory = "ProductCategory";
        public static readonly string ProductKind = "ProductKind";
        public static readonly string ProductLine = "ProductLine";
    }
}
