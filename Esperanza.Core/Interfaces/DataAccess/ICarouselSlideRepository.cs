using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface ICarouselSlideRepository : IGenericRepository<CarouselSlide>
    {
        Task<List<CarouselSlide>> GetByPagesIds(List<string> ids);
    }
}
