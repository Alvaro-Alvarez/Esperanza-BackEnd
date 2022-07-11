using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IImageService
    {
        void SavePhysicalPrincipalImage(PrincipalImage principalImage);
        void SavePhysicalGalleryImage(List<GalleryImage> galleryImages);
    }
}
