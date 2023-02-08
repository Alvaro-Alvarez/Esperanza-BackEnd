using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;

namespace Esperanza.Service.Business
{
    public class ImageService : IImageService
    {
        private const string extension = ".png";
        private const string base64Start = "data:image/jpeg;base64,";

        public void SavePhysicalImage(Image image, string directory)
        {
            if (!string.IsNullOrEmpty(image.Base64Image))
            {
                string imageName = image.Guid + extension;
                var bytes = Convert.FromBase64String(image.Base64Image.Split(",").Last());
                string filePath = directory + imageName;
                File.WriteAllBytes(filePath, bytes);
                image.FullName = imageName;
                image.Extension = extension;
            }
        }

        public void UpdatePhysicalImage(Image image, string directory)
        {
            var files = Directory.GetFiles(directory);
            var file = files.Where(f => f == $"{directory}{image.Guid}{extension}").FirstOrDefault();
            if (file != null) File.Delete(file);
            SavePhysicalImage(image, directory);

        }

        public string GetBase64RangeImage(string directory, string id)
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

        public void RemovePhysicalImage(Image image, string directory)
        {
            var files = Directory.GetFiles(directory);
            var file = files.Where(f => f == $"{directory}{image.Guid}{extension}").FirstOrDefault();
            if (file != null) File.Delete(file);

        }
    }
}
