using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class AppUser : Entity
    {
        public Guid? PersonGuid { get; set; }
        public Guid? RoleGuid { get; set; }
        public string? Email { get; set; }
        public string? Pass { get; set; }
        public string? BasClientCode { get; set; }
        public string? VerificationCode { get; set; }
        public bool? Verified { get; set; }
        public bool? CanCCM { get; set; }
        public bool? CanCCB { get; set; }
        public bool? Enabled { get; set; }

        [Description("ignore")]
        public Person? Person { get; set; }

        [Description("ignore")]
        public UserRole? UserRole { get; set; }


        [Description("ignore")]
        public static string GetAllFull
        {
            get
            {
                return @"SELECT * FROM AppUser u
                      INNER JOIN UserRole r ON u.RoleGuid = r.Guid
                      INNER JOIN Person p ON u.PersonGuid = p.Guid
                      LEFT JOIN DocumentType dt ON p.DocumentTypeGuid = dt.Guid
                      LEFT JOIN Sex s ON p.SexGuid = s.Guid
                      LEFT JOIN Phone ph ON p.PhoneGuid = ph.Guid
                      WHERE u.Deleted = 0";
            }
        }

        [Description("ignore")]
        public static string GetByGuid
        {
            get
            {
                return @"SELECT * FROM AppUser u
                        INNER JOIN UserRole ur ON ur.Guid = u.RoleGuid
                        WHERE u.Deleted = 0 AND U.Guid = @Guid;";
            }
        }

        [Description("ignore")]
        public static string GetByEmail
        {
            get
            {
                return @"SELECT * FROM AppUser u
                        INNER JOIN UserRole ur ON ur.Guid = u.RoleGuid
                        WHERE Email = @Email AND u.Deleted = 0;";
            }
        }

        [Description("ignore")]
        public static string Exist
        {
            get
            {
                return @"SELECT COUNT(*) FROM AppUser WHERE Deleted = 0 AND (Email = @Email OR BasClientCode = @BasClientCode);";
            }
        }

        [Description("ignore")]
        public static string UpdateVerificationCode
        {
            get
            {
                return @"UPDATE AppUser SET VerificationCode = @VerificationCode WHERE Email = @Email;";
            }
        }
    }
}
