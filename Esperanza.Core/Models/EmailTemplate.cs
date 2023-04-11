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
        public Guid? IdType { get; set; }

        [Description("ignore")]
        public List<EmailKeys>? EmailKeys { get; set; }


        [Description("ignore")]
        public static string GetByEmailType
        {
            get
            {
                return @"SELECT et.* FROM EmailType eType
                        INNER JOIN EmailTemplate et on et.IdType = eType.Guid
                        WHERE eType.[name] = @EmailType AND eType.Deleted = 0;";
            }
        }
    }
}
