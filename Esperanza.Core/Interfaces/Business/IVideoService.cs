using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IVideoService
    {
        void SavePhysicalVideo(Video video, string directory);
        void UpdatePhysicalVideo(Video video, string directory);
        string GetBase64RangeVideo(string directory, string id);
        void RemovePhysicalVideo(Video video, string directory);
    }
}
