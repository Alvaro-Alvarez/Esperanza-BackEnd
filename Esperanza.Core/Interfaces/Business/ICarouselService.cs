using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface ICarouselService
    {
        Task<List<CarouselPage>> GetAll();
        Task<CarouselPage> GetById(string id);
        Task<CarouselPage> GetByPageType(string pageType);
        Task<CarouselPage> Insert(CarouselPage page, string userId);
        Task<CarouselPage> Update(CarouselPage page, string userId);
        Task Delete(string id, string userId);
    }
}
