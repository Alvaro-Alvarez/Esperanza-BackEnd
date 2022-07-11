using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, IGenericRepository<SubCategory>
    {
        public SubCategoryRepository(IConnectionBuilder connectionBuilder) : base(Table.SubCategory, connectionBuilder)
        {

        }
    }
}
