using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IImageService
    {
        void SavePhysicalImage(Image image, string directory);
        void UpdatePhysicalImage(Image image, string directory);
        string GetBase64RangeImage(string directory, string id);
        void RemovePhysicalImage(Image image, string directory);
    }
}
