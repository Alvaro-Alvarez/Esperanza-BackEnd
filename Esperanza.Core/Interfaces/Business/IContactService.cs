using Esperanza.Core.Models;

namespace Esperanza.Core.Interfaces.Business
{
    public interface IContactService
    {
        Task SendContactMessage(ContactMessage message);
    }
}
