namespace Esperanza.Core.Models
{
    public class UserProduct : Entity
    {
        public Guid? ProductGuid { get; set; }
        public Guid? UserGuid { get; set; }
        public decimal? ProductPrice { get; set; }

        public static string GetAllByUser
        {
            get
            {
                return @"SELECT * FROM UserProduct WHERE UserGuid = @UserGuid;";
            }
        }
    }
}
