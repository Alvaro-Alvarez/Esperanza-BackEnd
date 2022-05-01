using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class OrderStatusRepository : GenericRepository<OrderStatus>, IGenericRepository<OrderStatus>
    {
        public OrderStatusRepository(IConnectionBuilder connectionBuilder) : base(Table.OrderStatus, connectionBuilder)
        {

        }
    }
}
