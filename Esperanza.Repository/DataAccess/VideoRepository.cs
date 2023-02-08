using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class VideoRepository : GenericRepository<Video>, IVideoRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public VideoRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.Video, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
