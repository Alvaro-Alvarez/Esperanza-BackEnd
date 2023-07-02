using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class Laboratory : Entity
    {
        public string? LaboratoryTitle { get; set; }
        public string? LaboratoryDescription { get; set; }
        public int? LaboratoryOrder { get; set; }
        public Guid? IdImage { get; set; }

        [Description("ignore")]
        public Image? Image { get; set; }

        [Description("ignore")]
        public static string GetAll
        {
            get
            {
                return @"SELECT * FROM Laboratory l
                        INNER JOIN Image img on l.IdImage = img.Guid
                        WHERE l.Deleted = 0;";
            }
        }

        [Description("ignore")]
        public static string GetTopFive
        {
            get
            {
                return @"SELECT TOP 5 * FROM Laboratory l
                        INNER JOIN Image img on l.IdImage = img.Guid
                        WHERE l.Deleted = 0;";
            }
        }

        [Description("ignore")]
        public static string GetById
        {
            get
            {
                return @"SELECT * FROM Laboratory l
                        INNER JOIN Image img on l.IdImage = img.Guid
                        WHERE l.Deleted = 0 AND l.Guid = @IdLaboratory;";
            }
        }
    }
}
