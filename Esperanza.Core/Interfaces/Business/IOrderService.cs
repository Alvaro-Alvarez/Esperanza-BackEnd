using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IOrderService
    {
        Task FinishOrder(OrderItems orderItems, string userId);
    }
}
