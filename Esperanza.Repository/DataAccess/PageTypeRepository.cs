using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class PageTypeRepository : GenericRepository<PageType>, IPageTypeRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public PageTypeRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.PageType, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
