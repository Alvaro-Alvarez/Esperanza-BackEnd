using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IUpSellingService
    {
        Task Insert(UpSelling upSelling);
    }
}
