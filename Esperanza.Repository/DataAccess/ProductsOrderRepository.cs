using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class ProductsOrderRepository : GenericRepository<ProductsOrder>, IProductsOrderRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public ProductsOrderRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.ProductsOrder, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }
    }
}
