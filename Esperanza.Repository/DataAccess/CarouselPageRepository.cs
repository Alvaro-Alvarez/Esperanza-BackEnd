using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class CarouselPageRepository : GenericRepository<CarouselPage>, ICarouselPageRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public CarouselPageRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.CarouselPage, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }

        public async Task<List<CarouselPage>> GetAll()
        {
            List<CarouselPage> pages;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                pages = (await db.QueryAsync<CarouselPage, PageType, CarouselPage>(
                CarouselPage.GetAll, (page, pageType) =>
                {
                    page.PageType = pageType;
                    return page;
                }, splitOn: "Guid")).ToList();
            }
            return pages;
        }

        public async Task<CarouselPage> GetByPageType(string pageType)
        {
            CarouselPage page;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                page = (await db.QueryAsync<CarouselPage>(CarouselPage.GetByPageType, new { PageType = pageType })).FirstOrDefault();
            }
            return page;
        }
    }
}
