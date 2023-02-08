using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;

namespace Esperanza.Service.Business
{
    public class VideoService : IVideoService
    {
        private const string extension = ".mp4";
        private const string base64Start = "data:image/jpeg;base64,";

        public void SavePhysicalVideo(Video video, string directory)
        {
            if (!string.IsNullOrEmpty(video.Base64Image))
            {
                string imageName = video.Guid + extension;
                var bytes = Convert.FromBase64String(video.Base64Image.Split(",").Last());
                string filePath = directory + imageName;
                File.WriteAllBytes(filePath, bytes);
                video.FullName = imageName;
                video.Extension = extension;
            }
        }
        public void UpdatePhysicalVideo(Video video, string directory)
        {
            var files = Directory.GetFiles(directory);
            var file = files.Where(f => f == $"{directory}{video.Guid}{extension}").FirstOrDefault();
            if (file != null) File.Delete(file);
            SavePhysicalVideo(video, directory);

        }
        public string GetBase64RangeVideo(string directory, string id)
        {
            try
            {
                var fileBytes = File.ReadAllBytes($"{directory}{id}{extension}");
                return $"{base64Start}{Convert.ToBase64String(fileBytes)}";
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
        public void RemovePhysicalVideo(Video video, string directory)
        {
            var files = Directory.GetFiles(directory);
            var file = files.Where(f => f == $"{directory}{video.Guid}{extension}").FirstOrDefault();
            if (file != null) File.Delete(file);
        }
    }
}
