using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Esperanza.Service.Helpers;
using Microsoft.Extensions.Options;

namespace Esperanza.Service.Business
{
    public class PromotionalVideoService : IPromotionalVideoService
    {
        private readonly IPromotionalVideoRepository PromotionalVideoRepository;
        private readonly IVideoService VideoService;
        private readonly IVideoRepository VideoRepository;
        private readonly ImageOptions Options;

        public PromotionalVideoService(
            IPromotionalVideoRepository promotionalVideoRepository,
            IVideoRepository videoRepository,
            IOptions<ImageOptions> options,
            IVideoService videoService
            )
        {
            PromotionalVideoRepository = promotionalVideoRepository;
            VideoRepository = videoRepository;
            VideoService = videoService;
            Options = options.Value;
        }
        public async Task<List<PromotionalVideo>> GetAll()
        {
            return await PromotionalVideoRepository.GetAll();
        }

        public async Task<List<PromotionalVideo>> GetTopFive()
        {
            return await PromotionalVideoRepository.GetTopFive();
        }

        public async Task<PromotionalVideo> GetById(string id)
        {
            return await PromotionalVideoRepository.GetById(id);
        }

        public async Task<PromotionalVideo> Insert(PromotionalVideo promotionalVideo, string userId)
        {
            InitIds(promotionalVideo, userId);
            if (promotionalVideo.ExternalVideo.HasValue && !promotionalVideo.ExternalVideo.Value)
                VideoService.SavePhysicalVideo(promotionalVideo.Video, Options.Videos);
            await VideoRepository.InsertAsync(promotionalVideo.Video);
            await PromotionalVideoRepository.InsertAsync(promotionalVideo);
            return await GetById(promotionalVideo.Guid.ToString());
        }

        public async Task<PromotionalVideo> Update(PromotionalVideo promotionalVideo, string userId)
        {
            InitUpdates(promotionalVideo, userId);
            if (promotionalVideo.ExternalVideo.HasValue && !promotionalVideo.ExternalVideo.Value)
                VideoService.SavePhysicalVideo(promotionalVideo.Video, Options.Videos);
            await VideoRepository.UpdateAsync(promotionalVideo.Video);
            await PromotionalVideoRepository.UpdateAsync(promotionalVideo);
            return await GetById(promotionalVideo.Guid.ToString());
        }

        public async Task Delete(string id, string userId)
        {
            var item = await GetById(id);
            InitUpdates(item, userId, delete: true);
            await VideoRepository.SoftDelete(item.IdVideo.ToString());
            await PromotionalVideoRepository.SoftDelete(item.Guid.ToString());
        }

        #region Private Methods
        private void InitIds(PromotionalVideo promotionalVideo, string userId)
        {
            EntityHelper.InitEntity(promotionalVideo, new Guid(userId));
            EntityHelper.InitEntity(promotionalVideo.Video, new Guid(userId));
            promotionalVideo.IdVideo = promotionalVideo.Video.Guid;
        }

        private void InitUpdates(PromotionalVideo promotionalVideo, string userId, bool delete = false)
        {
            EntityHelper.ModifyEntity(promotionalVideo, new Guid(userId));
            EntityHelper.ModifyEntity(promotionalVideo.Video, new Guid(userId));
            if (delete)
            {
                EntityHelper.ModifyEntity(promotionalVideo, new Guid(userId), delete: true);
                EntityHelper.ModifyEntity(promotionalVideo.Video, new Guid(userId), delete: true);
            }
        }
        #endregion
    }
}
