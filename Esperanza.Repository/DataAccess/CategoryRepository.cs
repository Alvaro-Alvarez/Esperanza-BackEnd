using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class CategoryRepository : GenericRepository<Category>, IGenericRepository<Category>
    {
        public CategoryRepository(IConnectionBuilder connectionBuilder) : base(Table.Category, connectionBuilder)
        {

        }
    }
}
