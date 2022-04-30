using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Repository.Constants
{
    public class Table
    {
        // Master Tables
        public static string DocumentType = "DocumentType";
        public static string Sex = "Sex";
        public static string Country = "Country";
        public static string City = "City";
        public static string Neighborhood = "Neighborhood";
        public static string UserRole = "UserRole";
        public static string Category = "Category";
        public static string Kind = "Kind";
        public static string Line = "Line";
        public static string OrderStatus = "OrderStatus";
        // Principal Tables
        public static string Phone = "Phone";
        public static string Address = "Address";
        public static string PrincipalImage = "PrincipalImage";
        public static string Product = "Product";
        public static string GalleryImage = "GalleryImage";
        public static string Person = "Person";
        public static string AppUser = "AppUser";
        public static string ProductsOrder = "ProductsOrder";
        // Intermediate Tables
        public static string OrderProduct = "OrderProduct";
        public static string AddressPerson = "AddressPerson";
        public static string ProductCategory = "ProductCategory";
        public static string ProductKind = "ProductKind";
        public static string ProductLine = "ProductLine";
    }
}
