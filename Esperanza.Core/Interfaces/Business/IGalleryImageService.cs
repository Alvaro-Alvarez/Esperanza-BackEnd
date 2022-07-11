using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IGalleryImageService
    {
        Task Insert(GalleryImage galleryImage);
    }
}
