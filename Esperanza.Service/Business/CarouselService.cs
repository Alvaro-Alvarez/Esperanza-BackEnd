using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Esperanza.Service.Helpers;
using Microsoft.Extensions.Options;

namespace Esperanza.Service.Business
{
    public class CarouselService : ICarouselService
    {
        private readonly ICarouselSlideRepository CarouselSlideRepository;
        private readonly ICarouselPageRepository CarouselPageRepository;
        private readonly ImageOptions Options;
        private readonly IImageService ImageService;
        private readonly IImageRepository ImageRepository;

        public CarouselService(
            ICarouselSlideRepository carouselSlideRepository,
            ICarouselPageRepository carouselPageRepository,
            IOptions<ImageOptions> options,
            IImageService imageService,
            IImageRepository imageRepository
            )
        {
            CarouselSlideRepository = carouselSlideRepository;
            CarouselPageRepository = carouselPageRepository;
            Options = options.Value;
            ImageRepository = imageRepository;
            ImageService = imageService;
        }

        public async Task<List<CarouselPage>> GetAll()
        {
            var pages = await CarouselPageRepository.GetAll();
            var slides = await CarouselSlideRepository.GetByPagesIds(pages.Select(p => p.Guid.ToString()).ToList());
            await Parallel.ForEachAsync(pages, async (page, cancellationToken) =>
            {
                page.Slides = slides.Where(s => s.IdCarouselPage.ToString() == page.Guid.ToString()).ToList();
            });
            return pages;
        }

        public async Task<CarouselPage> GetById(string id)
        {
            var page = await CarouselPageRepository.GetAsync(id);
            page.Slides = await CarouselSlideRepository.GetByPagesIds(new List<string>() { page.Guid.ToString() });
            return page;
        }

        public async Task<CarouselPage> GetByPageType(string pageType)
        {
            var page = await CarouselPageRepository.GetByPageType(pageType);
            if (page != null)
            {
                page.Slides = await CarouselSlideRepository.GetByPagesIds(new List<string>() { page.Guid.ToString() });
            }
            return page;
        }

        public async Task<CarouselPage> Insert(CarouselPage page, string userId)
        {
            InitIds(page, userId);
            await CarouselPageRepository.InsertAsync(page);
            foreach (var slide in page.Slides)
            {
                ImageService.SavePhysicalImage(slide.Image, Options.Carousel);
                await ImageRepository.InsertAsync(slide.Image);
                await CarouselSlideRepository.InsertAsync(slide);
            }            
            return await GetById(page.Guid.ToString());
        }

        public async Task<CarouselPage> Update(CarouselPage page, string userId)
        {
            InitUpdates(page, userId);
            await CarouselPageRepository.UpdateAsync(page);
            foreach (var slide in page.Slides)
            {
                if (slide.Deleted == true)
                {
                    EntityHelper.ModifyEntity(slide, new Guid(userId), delete: true);
                    EntityHelper.ModifyEntity(slide.Image, new Guid(userId), delete: true);
                    ImageService.RemovePhysicalImage(slide.Image, Options.Carousel);
                    await ImageRepository.UpdateAsync(slide.Image);
                    await CarouselSlideRepository.UpdateAsync(slide);
                }
                else
                {
                    if (slide.Guid == null)
                    {
                        EntityHelper.InitEntity(slide, new Guid(userId));
                        EntityHelper.InitEntity(slide.Image, new Guid(userId));
                        slide.IdImage = slide.Image.Guid;
                        slide.IdCarouselPage = page.Guid;
                        ImageService.SavePhysicalImage(slide.Image, Options.Carousel);
                        await ImageRepository.InsertAsync(slide.Image);
                        await CarouselSlideRepository.InsertAsync(slide);
                    }
                    else
                    {
                        ImageService.UpdatePhysicalImage(slide.Image, Options.Carousel);
                        await ImageRepository.UpdateAsync(slide.Image);
                        await CarouselSlideRepository.UpdateAsync(slide);
                    }
                }
            }
            return await GetById(page.Guid.ToString());
        }

        public async Task Delete(string id, string userId)
        {
            var item = await GetById(id);
            InitUpdates(item, userId, delete: true);
            await CarouselPageRepository.SoftDelete(item.Guid.ToString());
        }

        #region Private Methods
        private void InitIds(CarouselPage carouselPage, string userId)
        {
            EntityHelper.InitEntity(carouselPage, new Guid(userId));
            foreach (var slide in carouselPage.Slides)
            {
                EntityHelper.InitEntity(slide, new Guid(userId));
                EntityHelper.InitEntity(slide.Image, new Guid(userId));
                slide.IdImage = slide.Image.Guid;
                slide.IdCarouselPage = carouselPage.Guid;
            }
        }

        private void InitUpdates(CarouselPage carouselPage, string userId, bool delete = false)
        {
            EntityHelper.ModifyEntity(carouselPage, new Guid(userId));
            foreach (var slide in carouselPage.Slides)
            {
                EntityHelper.ModifyEntity(slide, new Guid(userId));
                EntityHelper.ModifyEntity(slide.Image, new Guid(userId));
            }
            if (delete)
            {
                EntityHelper.ModifyEntity(carouselPage, new Guid(userId), delete: true);
                foreach (var slide in carouselPage.Slides)
                {
                    EntityHelper.ModifyEntity(slide, new Guid(userId), delete: true);
                    EntityHelper.ModifyEntity(slide.Image, new Guid(userId), delete: true);
                }
            }
        }
        #endregion
    }
}
