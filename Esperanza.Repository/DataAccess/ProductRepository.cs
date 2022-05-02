using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public ProductRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.Product, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
