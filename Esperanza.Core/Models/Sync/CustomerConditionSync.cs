using System.ComponentModel;

namespace Esperanza.Core.Models.Sync
{
    public class CustomerConditionSync : Entity
    {
        public string CODCTACTE { get; set; }
        public string CODCONDI { get; set; }
        public string CODLIS { get; set; }
        public string COLUMNA { get; set; }

        [Description("ignore")]
        public static string GetByClientAndCondition
        {
            get
            {
                return @"select * from CustomerConditionSync where CODCTACTE = @ClientCode AND CODCONDI = @Condition;";
            }
        }

        [Description("ignore")]
        public static string DeleteAll
        {
            get
            {
                return @"delete from CustomerConditionSync;";
            }
        }
    }
}
