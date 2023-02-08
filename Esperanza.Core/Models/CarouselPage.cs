using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class CarouselPage : Entity
    {
        public CarouselPage()
        {

        }

        public Guid? IdPageType { get; set; }
        public bool? Enable { get; set; }

        [Description("ignore")]
        public PageType? PageType { get; set; }

        [Description("ignore")]
        public List<CarouselSlide>? Slides { get; set; }

        [Description("ignore")]
        public static string GetByPageType
        {
            get
            {
                return @"SELECT * FROM CarouselPage pg
                        INNER JOIN PageType pt ON pt.Guid = pg.IdPageType
                        WHERE pt.Name = @PageType;";
            }
        }

        [Description("ignore")]
        public static string GetAll
        {
            get
            {
                return @"SELECT * FROM CarouselPage p
                        INNER JOIN PageType pt on p.IdPageType = pt.Guid
                        WHERE p.Deleted = 0;";
            }
        }
    }
}
