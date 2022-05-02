using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class GalleryImageRepository : GenericRepository<GalleryImage>, IGalleryImageRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public GalleryImageRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.GalleryImage, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
