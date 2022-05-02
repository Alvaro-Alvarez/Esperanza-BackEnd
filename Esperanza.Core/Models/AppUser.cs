using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Models
{
    public class AppUser : Entity
    {
        public Guid? PersonGuid { get; set; }
        public Guid? RoleGuid { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public bool? Verified { get; set; }

        [Description("ignore")]
        public Person? Person { get; set; }

        [Description("ignore")]
        public UserRole? UserRole { get; set; }

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
    }
}
