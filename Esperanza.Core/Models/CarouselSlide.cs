using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class CarouselSlide : Entity
    {
        public string? SlideText { get; set; }
        public int? SlideOrder { get; set; }
        public bool? IsPhoneDimension { get; set; }
        public Guid? IdCarouselPage { get; set; }
        public Guid? IdImage { get; set; }

        [Description("ignore")]
        public Image? Image { get; set; }

        [Description("ignore")]
        public static string GetByPagesIds
        {
            get
            {
                return @"SELECT * FROM CarouselSlide slide
                        INNER JOIN Image img on slide.IdImage = img.Guid
                        WHERE slide.IdCarouselPage IN @IdCarouselPages AND slide.Deleted = 0";
            }
        }
    }
}
