using Esperanza.Core.Constants;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Logs;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Esperanza.Core.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Text;

namespace Esperanza.Service.Business
{
    public class OrderService : IOrderService
    {
        private readonly IEmailService _emailService;
        private readonly IAppUserRepository UserRepository;
        private readonly ICustomerConditionSyncRepository CustomerConditionSyncRepository;
        private readonly OrderServiceOptions OrderOptions;
        private readonly Logs LogsSettings;
        private readonly EmailOptions EmailSettings;

        public OrderService(
            IEmailService emailService,
            IAppUserRepository userRepository,
            ICustomerConditionSyncRepository customerConditionSyncRepository,
            IOptions<OrderServiceOptions> options,
            IOptions<Logs> logsSettings,
            IOptions<EmailOptions> emailSettings
            )
        {
            _emailService = emailService;
            CustomerConditionSyncRepository = customerConditionSyncRepository;
            UserRepository = userRepository;
            OrderOptions = options.Value;
            LogsSettings = logsSettings.Value;
            EmailSettings = emailSettings.Value;
        }

        public async Task FinishOrder(OrderItems orderItems, string userId)
        {
            //string asd = "asdasdads".Substring(1,214);
            var user = await UserRepository.GetUserAsync(new Guid(userId));
            Log.Information(LogsSettings.Path, JsonConvert.SerializeObject(user), prefix: "Usuario --> ");
            if (orderItems.OrderCcb != null)
            {
                var customerCondition = await CustomerConditionSyncRepository.GetByClientAndCondition(user.BasClientCode, "CCB");
                orderItems.OrderCcb.PedidoVenta.ListaPrecios = customerCondition.CODLIS;
                string payloadCcb = JsonConvert.SerializeObject(orderItems.OrderCcb);
                Log.Information(LogsSettings.Path, payloadCcb, prefix: "FinishOrder - Payload CCB");
                var httpClient = new HttpClient();
                var content = new StringContent(payloadCcb, Encoding.UTF8, "application/json");
                var res = await httpClient.PostAsync($"{OrderOptions.ApiUrl}{OrderOptions.OrderController}", content);
                Log.Information(LogsSettings.Path, JsonConvert.SerializeObject(res), prefix: "Obtiene respuesta CCB -->");
                if (!res.IsSuccessStatusCode)
                    throw new Exception($"Error al realizar el pedido ccb. Cliente {orderItems.OrderCcb.PedidoVenta.Cliente}. Información del error: {JsonConvert.SerializeObject(res)}");
                var resContent = await res.Content.ReadAsStringAsync();
                if (resContent.Contains("Error"))
                    throw new Exception($"Error al realizar el pedido ccb. Cliente {orderItems.OrderCcb.PedidoVenta.Cliente}. Información del error: {JsonConvert.SerializeObject(resContent)} | {JsonConvert.SerializeObject(res)}");
                Log.Information(LogsSettings.Path, JsonConvert.SerializeObject(resContent), prefix: "Obtiene contenido respuesta CCB -->");

            }
            if (orderItems.OrderCcm != null)
            {
                var customerCondition = await CustomerConditionSyncRepository.GetByClientAndCondition(user.BasClientCode, "CCM");
                orderItems.OrderCcm.PedidoVenta.ListaPrecios = customerCondition.CODLIS;
                string payloadCcm = JsonConvert.SerializeObject(orderItems.OrderCcm);
                Log.Information(LogsSettings.Path, payloadCcm, prefix: "FinishOrder - Payload CCM");
                var httpClient = new HttpClient();
                var content = new StringContent(payloadCcm, Encoding.UTF8, "application/json");
                var res = await httpClient.PostAsync($"{OrderOptions.ApiUrl}{OrderOptions.OrderController}", content);
                Log.Information(LogsSettings.Path, JsonConvert.SerializeObject(res), prefix: "Obtiene respuesta CCM -->");
                if (!res.IsSuccessStatusCode)
                    throw new Exception($"Error al realizar el pedido ccm. Cliente {orderItems.OrderCcm.PedidoVenta.Cliente}. Información del error: {JsonConvert.SerializeObject(res)}");
                var resContent = await res.Content.ReadAsStringAsync();
                if (resContent.Contains("Error"))
                    throw new Exception($"Error al realizar el pedido ccm. Cliente {orderItems.OrderCcm.PedidoVenta.Cliente}. Información del error: {JsonConvert.SerializeObject(resContent)} | {JsonConvert.SerializeObject(res)}");
                Log.Information(LogsSettings.Path, JsonConvert.SerializeObject(resContent), prefix: "Obtiene contenido respuesta CCM -->");
            }
            await _emailService.SendMail(EmailTypeConstant.OrderPlaced, new Dictionary<string, string>(), new List<string>() { user.Email, EmailSettings.ContactEmail });
        }
    }
}
