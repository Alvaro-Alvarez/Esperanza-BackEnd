using Dapper;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Esperanza.Core.Models.Request;
using Esperanza.Core.Models.SPs;
using Esperanza.Repository.Constants;
using Microsoft.Extensions.Options;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class PromotionalVideoRepository : GenericRepository<PromotionalVideo>, IPromotionalVideoRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;
        private readonly IVideoService VideoService;
        private readonly IImageService ImageService;
        private readonly ImageOptions Options;

        public PromotionalVideoRepository(
            IConnectionBuilder connectionBuilder,
            IOptions<ImageOptions> options,
            IVideoService videoService,
            IImageService imageService
            ) : base(Table.PromotionalVideo, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
            Options = options.Value;
            VideoService = videoService;
            ImageService = imageService;
        }

        public async Task<List<PromotionalVideo>> GetAll()
        {
            List<PromotionalVideo> promotionalVideos;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                promotionalVideos = (await db.QueryAsync<PromotionalVideo, Video, Image, PromotionalVideo>(
                PromotionalVideo.GetAll, (promotionalVideo, video, image) =>
                {
                    //promotionalVideo.Video = video;
                    promotionalVideo.Thumbnail = image;
                    //promotionalVideo.Video.Base64Image = VideoService.GetBase64RangeVideo(Options.Videos, promotionalVideo.IdVideo.ToString());
                    promotionalVideo.Thumbnail.Base64Image = ImageService.GetBase64RangeImage(Options.VideoThumbnail, promotionalVideo.IdThumbnail.ToString());
                    return promotionalVideo;
                }, splitOn: "Guid,Guid")).ToList();
            }
            return promotionalVideos;
        }

        public async Task<List<PromotionalVideo>> GetTopFive()
        {
            List<PromotionalVideo> promotionalVideos;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                promotionalVideos = (await db.QueryAsync<PromotionalVideo, Video, Image, PromotionalVideo>(
                PromotionalVideo.GetTopFive, (promotionalVideo, video, image) =>
                {
                    //promotionalVideo.Video = video;
                    promotionalVideo.Thumbnail = image;
                    //promotionalVideo.Video.Base64Image = VideoService.GetBase64RangeVideo(Options.Videos, promotionalVideo.IdVideo.ToString());
                    promotionalVideo.Thumbnail.Base64Image = ImageService.GetBase64RangeImage(Options.VideoThumbnail, promotionalVideo.IdThumbnail.ToString());
                    return promotionalVideo;
                }, splitOn: "Guid,Guid")).ToList();
            }
            return promotionalVideos;
        }

        public async Task<List<VideoSp>> GetAllSp(Pagination pagination)
        {
            List<VideoSp> videos;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                videos = db.Query<VideoSp>("GetAllVideosPagination", new { Start = pagination.Start },
                            commandType: CommandType.StoredProcedure).ToList();
            }
            await Parallel.ForEachAsync(videos, async (video, cancellationToken) =>
            {
                video.Base64Image = ImageService.GetBase64RangeImage(Options.VideoThumbnail, video.IdImage.ToString());
            });
            return videos;
        }

        public async Task<PromotionalVideo> GetById(string id)
        {
            PromotionalVideo promotionalVideo;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                promotionalVideo = (await db.QueryAsync<PromotionalVideo, Video, Image, PromotionalVideo>(
                PromotionalVideo.GetById, (promotionalVideo, video, image) =>
                {
                    promotionalVideo.Video = video;
                    promotionalVideo.Thumbnail = image;
                    promotionalVideo.Video.Base64Image = VideoService.GetBase64RangeVideo(Options.Videos, promotionalVideo.IdVideo.ToString());
                    promotionalVideo.Thumbnail.Base64Image = ImageService.GetBase64RangeImage(Options.VideoThumbnail, promotionalVideo.IdThumbnail.ToString());
                    return promotionalVideo;
                }, new { IdPromotionalVideo = id }, splitOn: "Guid,Guid")).FirstOrDefault();
            }
            return promotionalVideo;
        }
    }
}
