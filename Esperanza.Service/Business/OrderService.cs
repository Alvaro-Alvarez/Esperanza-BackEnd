using Esperanza.Core.Constants;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;

namespace Esperanza.Service.Business
{
    public class OrderService : IOrderService
    {
        private readonly IEmailService _emailService;

        public OrderService(
            IEmailService emailService
            )
        {
            _emailService = emailService;
        }

        public async Task FinishOrder(Order order)
        {
            // TODO: Completar el diccionario de claves y emails receptores
            await _emailService.SendMail(EmailTypeConstant.OrderPlaced ,new Dictionary<string, string>(), new List<string>());
        }
    }
}
