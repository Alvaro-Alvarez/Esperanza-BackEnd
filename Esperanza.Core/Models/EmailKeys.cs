using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class EmailKeys : Entity
    {
        public string? Key { get; set; }
        public string? FieldNameValue { get; set; }
        public string? IdTemplate { get; set; }

        [Description("ignore")]
        public static string GetKeyByTemplateId
        {
            get
            {
                return @"SELECT * FROM EmailKeys WHERE IdTemplate = @IdTemplate;";
            }
        }
    }
}
