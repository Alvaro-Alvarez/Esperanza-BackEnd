using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class Person : Entity
    {
        public Guid? DocumentTypeGuid { get; set; }
        public Guid? PhoneGuid { get; set; }
        public Guid? SexGuid { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string DocumentNumber { get; set; }

        [Description("ignore")]
        public DocumentType? DocumentType { get; set; }

        [Description("ignore")]
        public Sex? Sex { get; set; }

        [Description("ignore")]
        public Phone? Phone { get; set; }

        [Description("ignore")]
        public static string GetByGuid
        {
            get
            {
                return @"SELECT * FROM Person p
                        INNER JOIN Sex s on s.Guid = p.SexGuid
                        INNER JOIN DocumentType d on d.Guid = p.DocumentTypeGuid
                        INNER JOIN Phone ph on ph.Guid = p.PhoneGuid
                        WHERE P.Deleted = 0 AND p.Guid = @Guid;";
            }
        }
    }
}
