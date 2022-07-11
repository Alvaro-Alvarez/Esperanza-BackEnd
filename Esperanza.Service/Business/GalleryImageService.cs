using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;

namespace Esperanza.Service.Business
{
    public class GalleryImageService : IGalleryImageService
    {
        private readonly IGalleryImageRepository GalleryImageRepository;
        public GalleryImageService(IGalleryImageRepository galleryImageRepository)
        {
            GalleryImageRepository = galleryImageRepository;
        }

        public async Task Insert(GalleryImage galleryImage)
        {
            await GalleryImageRepository.InsertAsync(galleryImage);
        }
    }
}
