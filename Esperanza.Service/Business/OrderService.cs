using Esperanza.Core.Constants;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Core.Models.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace Esperanza.Service.Business
{
    public class OrderService : IOrderService
    {
        private readonly IEmailService _emailService;
        private readonly IAppUserRepository UserRepository;
        private readonly ICustomerConditionSyncRepository CustomerConditionSyncRepository;
        private readonly OrderServiceOptions OrderOptions;

        public OrderService(
            IEmailService emailService,
            IAppUserRepository userRepository,
            ICustomerConditionSyncRepository customerConditionSyncRepository,
            IOptions<OrderServiceOptions> options
            )
        {
            _emailService = emailService;
            CustomerConditionSyncRepository = customerConditionSyncRepository;
            UserRepository = userRepository;
            OrderOptions = options.Value;
        }

        public async Task FinishOrder(OrderItems orderItems, string userId)
        {
            var user = await UserRepository.GetUserAsync(new Guid(userId));
            if (orderItems.OrderCcb != null)
            {
                var customerCondition = await CustomerConditionSyncRepository.GetByClientAndCondition(user.BasClientCode, "CCB");
                orderItems.OrderCcb.PedidoVenta.ListaPrecios = customerCondition.CODLIS;
                string payloadCcb = JsonConvert.SerializeObject(orderItems.OrderCcb);
                var clientCcb = new RestClient(OrderOptions.ApiUrl);
                var requestCcb = new RestRequest(OrderOptions.OrderController, Method.Post);
                requestCcb.AddParameter("application/json; charset=utf-8", payloadCcb, ParameterType.RequestBody);
                requestCcb.AddHeader("content-type", "application/json");
                requestCcb.AddHeader("ETIQUETA", "PEDIDOS BASICOS");
                requestCcb.AddHeader("CODEMP", orderItems.OrderCcb.PedidoVenta.Empresa);
                requestCcb.AddHeader("CODSUC", orderItems.OrderCcb.PedidoVenta.Sucursal);
                requestCcb.AddHeader("FECHA", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                var resCcb = await clientCcb.ExecuteAsync(requestCcb);
                if (!resCcb.IsSuccessful)
                    throw new Exception($"Error al realizar el pedido CCB. Información del error: {resCcb.ErrorMessage} - {resCcb.ErrorException}");
            }
            if (orderItems.OrderCcm != null)
            {
                var customerCondition = await CustomerConditionSyncRepository.GetByClientAndCondition(user.BasClientCode, "CCM");
                orderItems.OrderCcm.PedidoVenta.ListaPrecios = customerCondition.CODLIS;
                string payloadCcm = JsonConvert.SerializeObject(orderItems.OrderCcm);
                var clientCcb = new RestClient(OrderOptions.ApiUrl);
                var requestCcm = new RestRequest(OrderOptions.OrderController, Method.Post);
                requestCcm.AddParameter("application/json; charset=utf-8", payloadCcm, ParameterType.RequestBody);
                requestCcm.AddHeader("content-type", "application/json");
                requestCcm.AddHeader("ETIQUETA", "PEDIDOS BASICOS");
                requestCcm.AddHeader("CODEMP", orderItems.OrderCcm.PedidoVenta.Empresa);
                requestCcm.AddHeader("CODSUC", orderItems.OrderCcm.PedidoVenta.Sucursal);
                requestCcm.AddHeader("FECHA", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                var resCcm = await clientCcb.ExecuteAsync(requestCcm);
                if (!resCcm.IsSuccessful)
                    throw new Exception($"Error al realizar el pedido CCM. Información del error: {resCcm.ErrorMessage} - {resCcm.ErrorException}");
            }
            // TODO: Completar el diccionario de claves y emails receptores
            await _emailService.SendMail(EmailTypeConstant.OrderPlaced ,new Dictionary<string, string>(), new List<string>() { user.Email });
        }

        #region Private Methods
        //private bool SuccessfulRequest(IRestResponse response)
        //{
        //    return response.StatusCode == HttpStatusCode.Created
        //        || response.StatusCode == HttpStatusCode.NoContent
        //        || response.StatusCode == HttpStatusCode.OK
        //        || response.IsSuccessful;
        //}
        #endregion
    }
}
