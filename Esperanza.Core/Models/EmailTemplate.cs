using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class EmailTemplate : Entity
    {
        public EmailTemplate()
        {
            EmailKeys = new List<EmailKeys>();
        }

        public string? Subject { get; set; }
        public string? Template { get; set; }
        public int? IdType { get; set; }

        [Description("ignore")]
        public List<EmailKeys>? EmailKeys { get; set; }


        [Description("ignore")]
        public static string GetByEmailType
        {
            get
            {
                return @"SELECT * FROM EmailTemplate WHERE name = @EmailType AND Deleted = false;";
            }
        }
    }
}
