using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class PromotionalVideo : Entity
    {
        public string? VideoTitle { get; set; }
        public string? VideoDescription { get; set; }
        public Guid? IdVideo { get; set; }
        public Guid? IdThumbnail { get; set; }
        public bool? ExternalVideo { get; set; }
        public string? ExternalLink{ get; set; }

        [Description("ignore")]
        public Image? Thumbnail { get; set; }

        [Description("ignore")]
        public Video? Video { get; set; }

        [Description("ignore")]
        public static string GetAll
        {
            get
            {
                return @"SELECT * FROM PromotionalVideo pv
                        INNER JOIN Video v on pv.IdVideo = v.Guid
                        INNER JOIN Image i on pv.IdThumbnail = i.Guid
                        WHERE pv.Deleted = 0;";
            }
        }

        [Description("ignore")]
        public static string GetTopFive
        {
            get
            {
                return @"SELECT TOP 5 * FROM PromotionalVideo pv
                        INNER JOIN Video v on pv.IdVideo = v.Guid
                        INNER JOIN Image i on pv.IdThumbnail = i.Guid
                        WHERE pv.Deleted = 0;";
            }
        }

        [Description("ignore")]
        public static string GetById
        {
            get
            {
                return @"SELECT * FROM PromotionalVideo pv
                        INNER JOIN Video v on pv.IdVideo = v.Guid
                        INNER JOIN Image i on pv.IdThumbnail = i.Guid
                        WHERE pv.Deleted = 0 AND pv.Guid = @IdPromotionalVideo;";
            }
        }
    }
}
