using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface ICrossSellingService
    {
        Task Insert(CrossSelling crossSelling);
    }
}
