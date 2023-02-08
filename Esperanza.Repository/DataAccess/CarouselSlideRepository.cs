using Dapper;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Esperanza.Repository.Constants;
using Microsoft.Extensions.Options;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class CarouselSlideRepository : GenericRepository<CarouselSlide>, ICarouselSlideRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;
        private readonly ImageOptions Options;
        private readonly IImageService ImageService;

        public CarouselSlideRepository(
            IConnectionBuilder connectionBuilder,
            IOptions<ImageOptions> options,
            IImageService imageService
            ) : base(Table.CarouselSlide, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
            Options = options.Value;
            ImageService = imageService;
        }

        public async Task<List<CarouselSlide>> GetByPagesIds(List<string> ids)
        {
            List<CarouselSlide> slides;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                slides = (await db.QueryAsync<CarouselSlide, Image, CarouselSlide>(
                CarouselSlide.GetByPagesIds, (slide, image) =>
                {
                    slide.Image = image;
                    slide.Image.Base64Image = ImageService.GetBase64RangeImage(Options.Carousel, slide.IdImage.ToString());
                    return slide;
                }, new { IdCarouselPages = ids }, splitOn: "Guid")).ToList();
            }
            return slides;
        }
    }
}
