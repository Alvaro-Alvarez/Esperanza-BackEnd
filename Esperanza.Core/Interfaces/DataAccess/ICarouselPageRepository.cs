using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface ICarouselPageRepository : IGenericRepository<CarouselPage>
    {
        Task<CarouselPage> GetByPageType(string pageType);
        Task<List<CarouselPage>> GetAll();
    }
}
