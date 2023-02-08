using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public ImageRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.Image, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
