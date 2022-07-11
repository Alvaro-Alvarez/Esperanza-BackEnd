using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Service.Business
{
    public class ImageService : IImageService
    {
        private readonly ImageOptions Options;

        public ImageService(
            IOptions<ImageOptions> options
            )
        {
            Options = options.Value;
        }

        public void SavePhysicalPrincipalImage(PrincipalImage principalImage)
        {
            // TODO: Eliminar la imagen para volver a meterla, ya que si editas no hay manera de saber si es una nueva imagen
            if (!string.IsNullOrEmpty(principalImage.Base64Image))
            {
                string extension = ".jpg";
                string imageName = principalImage.Guid + extension;
                var bytes = Convert.FromBase64String(principalImage.Base64Image.Split(",").Last());
                string filePath = Options.Principal + imageName;
                File.WriteAllBytes(filePath, bytes);
                principalImage.FullName = imageName;
                principalImage.Extension = extension;
                principalImage.ImagePath = "assets" + filePath.Split("assets").Last();
            }

        }
        public void SavePhysicalGalleryImage(List<GalleryImage> galleryImages)
        {
            foreach (var galleryImage in galleryImages)
            {
                if (!string.IsNullOrEmpty(galleryImage.Base64Image))
                {
                    string extension = ".jpg";
                    string imageName = galleryImage.Guid + extension;
                    var bytes = Convert.FromBase64String(galleryImage.Base64Image.Split(",").Last());
                    string filePath = Options.Gallery + imageName;
                    File.WriteAllBytes(filePath, bytes);
                    galleryImage.FullName = imageName;
                    galleryImage.Extension = extension;
                    galleryImage.ImagePath = "assets" + filePath.Split("assets").Last();
                }
            }

        }
    }
}
