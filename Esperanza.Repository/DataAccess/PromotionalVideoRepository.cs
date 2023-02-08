using Dapper;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Esperanza.Repository.Constants;
using Microsoft.Extensions.Options;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class PromotionalVideoRepository : GenericRepository<PromotionalVideo>, IPromotionalVideoRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;
        private readonly IVideoService VideoService;
        private readonly ImageOptions Options;

        public PromotionalVideoRepository(
            IConnectionBuilder connectionBuilder,
            IOptions<ImageOptions> options,
            IVideoService videoService
            ) : base(Table.PromotionalVideo, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
            Options = options.Value;
            VideoService = videoService;
        }

        public async Task<List<PromotionalVideo>> GetAll()
        {
            List<PromotionalVideo> promotionalVideos;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                promotionalVideos = (await db.QueryAsync<PromotionalVideo, Video, PromotionalVideo>(
                PromotionalVideo.GetAll, (promotionalVideo, video) =>
                {
                    promotionalVideo.Video = video;
                    promotionalVideo.Video.Base64Image = VideoService.GetBase64RangeVideo(Options.Videos, promotionalVideo.IdVideo.ToString());
                    return promotionalVideo;
                }, splitOn: "Guid")).ToList();
            }
            return promotionalVideos;
        }

        public async Task<List<PromotionalVideo>> GetTopFive()
        {
            List<PromotionalVideo> promotionalVideos;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                promotionalVideos = (await db.QueryAsync<PromotionalVideo, Video, PromotionalVideo>(
                PromotionalVideo.GetTopFive, (promotionalVideo, video) =>
                {
                    promotionalVideo.Video = video;
                    promotionalVideo.Video.Base64Image = VideoService.GetBase64RangeVideo(Options.Videos, promotionalVideo.IdVideo.ToString());
                    return promotionalVideo;
                }, splitOn: "Guid")).ToList();
            }
            return promotionalVideos;
        }

        public async Task<PromotionalVideo> GetById(string id)
        {
            PromotionalVideo promotionalVideo;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                promotionalVideo = (await db.QueryAsync<PromotionalVideo, Video, PromotionalVideo>(
                PromotionalVideo.GetById, (promotionalVideo, video) =>
                {
                    promotionalVideo.Video = video;
                    promotionalVideo.Video.Base64Image = VideoService.GetBase64RangeVideo(Options.Videos, promotionalVideo.IdVideo.ToString());
                    return promotionalVideo;
                }, new { IdPromotionalVideo = id }, splitOn: "Guid")).FirstOrDefault();
            }
            return promotionalVideo;
        }
    }
}
