using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Esperanza.Service.Helpers;
using Microsoft.Extensions.Options;

namespace Esperanza.Service.Business
{
    public class LaboratoryService : ILaboratoryService
    {
        private readonly ILaboratoryRepository LaboratoryRepository;
        private readonly IImageService ImageService;
        private readonly IImageRepository ImageRepository;
        private readonly ImageOptions Options;

        public LaboratoryService(
            ILaboratoryRepository laboratoryRepository,
            IImageRepository imageRepository,
            IOptions<ImageOptions> options,
            IImageService imageService
            )
        {
            LaboratoryRepository = laboratoryRepository;
            ImageRepository = imageRepository;
            ImageService = imageService;
            Options = options.Value;
        }

        public async Task<List<Laboratory>> GetAll()
        {
            return await LaboratoryRepository.GetAll();
        }

        public async Task<List<Laboratory>> GetTopFive()
        {
            return await LaboratoryRepository.GetTopFive();
        }

        public async Task<Laboratory> GetById(string id)
        {
            return await LaboratoryRepository.GetById(id);
        }

        public async Task<Laboratory> Insert(Laboratory laboratory, string userId)
        {
            InitIds(laboratory, userId);
            ImageService.SavePhysicalImage(laboratory.Image, Options.Laboratory);
            await ImageRepository.InsertAsync(laboratory.Image);
            await LaboratoryRepository.InsertAsync(laboratory);
            return await GetById(laboratory.Guid.ToString());
        }

        public async Task<Laboratory> Update(Laboratory laboratory, string userId)
        {
            InitUpdates(laboratory, userId);
            ImageService.UpdatePhysicalImage(laboratory.Image, Options.Laboratory);
            await ImageRepository.UpdateAsync(laboratory.Image);
            await LaboratoryRepository.UpdateAsync(laboratory);
            return await GetById(laboratory.Guid.ToString());
        }

        public async Task Delete(string id, string userId)
        {
            var item = await GetById(id);
            InitUpdates(item, userId, delete: true);
            await ImageRepository.SoftDelete(item.IdImage.ToString());
            await LaboratoryRepository.SoftDelete(item.Guid.ToString());
        }

        #region Private Methods
        private void InitIds(Laboratory laboratory, string userId)
        {
            EntityHelper.InitEntity(laboratory, new Guid(userId));
            EntityHelper.InitEntity(laboratory.Image, new Guid(userId));
            laboratory.IdImage = laboratory.Image.Guid;
        }

        private void InitUpdates(Laboratory laboratory, string userId, bool delete = false)
        {
            EntityHelper.ModifyEntity(laboratory, new Guid(userId));
            EntityHelper.ModifyEntity(laboratory.Image, new Guid(userId));
            if (delete)
            {
                EntityHelper.ModifyEntity(laboratory, new Guid(userId), delete: true);
                EntityHelper.ModifyEntity(laboratory.Image, new Guid(userId), delete: true);
            }
        }
        #endregion
    }
}
