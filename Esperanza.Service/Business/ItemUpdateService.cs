using AutoMapper;
using Esperanza.Core.Constants;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models.Options;
using Esperanza.Core.Models.Services;
using Esperanza.Core.Models.Sync;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace Esperanza.Service.Business
{
    public class ItemUpdateService : IItemUpdateService
    {
        private readonly ServicesOption _servicesOption;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<PropductSync> _propductSyncRepository;
        private readonly IGenericRepository<CustomerSync> _customerSyncRepository;
        private readonly ICustomerConditionSyncRepository _customerConditionSyncRepository;
        private readonly IGenericRepository<PriceListSync> _priceListSyncRepository;
        private readonly IGenericRepository<TransportSync> _transportSyncRepository;

        public ItemUpdateService(
            IOptions<ServicesOption> servicesOption,
            IMapper mapper,
            IGenericRepository<PropductSync> propductSyncRepository,
            IGenericRepository<CustomerSync> customerSyncRepository,
            ICustomerConditionSyncRepository customerConditionSyncRepository,
            IGenericRepository<PriceListSync> priceListSyncRepository,
            IGenericRepository<TransportSync> transportSyncRepository
            )
        {
            _servicesOption = servicesOption.Value;
            _propductSyncRepository = propductSyncRepository;
            _customerSyncRepository = customerSyncRepository;
            _customerConditionSyncRepository = customerConditionSyncRepository;
            _priceListSyncRepository = priceListSyncRepository;
            _transportSyncRepository = transportSyncRepository;
            _mapper = mapper;
        }

        public async Task UpdateProducts()
        {
            ////TODO: Tomar el campo "ACTUALIZADO" para ver si actualizar el item o no, tambien llamar el endpoint final para decirle que ya fueron actualizados.
            //const int maxItems = 4200;
            //const int itemsPerPage = 300;
            //int init = 1;
            //var items = new List<Item>();
            //for (int i = 0; i < maxItems; i = i + itemsPerPage)
            //{
            //    var setItems = await GetData<List<Item>>($"{_servicesOption.ItemsController}&PAGINA={itemsPerPage}&DESDE={init}");
            //    items.AddRange(setItems);
            //    init += itemsPerPage;
            //}
            //var insertedCodes = (await _propductSyncRepository.GetProductCodes()).ToList();
            //var recordToInsert = GetRecordToInsert(items, insertedCodes, SyncCodeConstant.Product);
            //var recordToRemove = insertedCodes.Except(items.Select(i => i.CODIGO)).ToList();
            //var itemsToSave = _mapper.Map<List<PropductSync>>(recordToInsert);
            //itemsToSave.ForEach(item =>
            //{
            //    item.Guid = Guid.NewGuid();
            //    item.CreatedAt = DateTime.Now;
            //    item.CreatedBy = Guid.Empty;
            //});
            //await _propductSyncRepository.SaveRangeAsync(itemsToSave);
            //await _propductSyncRepository.DeleteRowsRange(recordToRemove, SyncCodeConstant.Product);

            //TODO: Tomar el campo "ACTUALIZADO" para ver si actualizar el item o no, tambien llamar el endpoint final para decirle que ya fueron actualizados.
            var items = await GetData<List<Item>>(_servicesOption.ItemsController);
            var insertedCodes = (await _propductSyncRepository.GetProductCodes()).ToList();
            var recordToInsert = GetRecordToInsert(items, insertedCodes, SyncCodeConstant.Product);
            var recordToRemove = insertedCodes.Except(items.Select(i => i.CODIGO)).ToList();
            var itemsToSave = _mapper.Map<List<PropductSync>>(recordToInsert);
            itemsToSave.ForEach(item =>
            {
                item.Guid = Guid.NewGuid();
                item.CreatedAt = DateTime.Now;
                item.CreatedBy = Guid.Empty;
            });
            await _propductSyncRepository.SaveRangeAsync(itemsToSave);
            await _propductSyncRepository.DeleteRowsRange(recordToRemove, SyncCodeConstant.Product);

        }

        public async Task UpdateCtaCte()
        {
            var items = await GetData<List<CtaCte>>(_servicesOption.CtaCteController);
            var insertedCodes = (await _customerSyncRepository.GetCustomerCodes()).ToList();
            var recordToInsert = GetRecordToInsert(items, insertedCodes, SyncCodeConstant.Customer);
            var recordToRemove = insertedCodes.Except(items.Select(i => i.CODCTACTE)).ToList();
            var itemsToSave = _mapper.Map<List<CustomerSync>>(recordToInsert);
            itemsToSave.ForEach(item =>
            {
                item.Guid = Guid.NewGuid();
                item.CreatedAt = DateTime.Now;
                item.CreatedBy = Guid.Empty;
            });
            await _customerSyncRepository.SaveRangeAsync(itemsToSave);
            await _customerSyncRepository.DeleteRowsRange(recordToRemove, SyncCodeConstant.Customer);
        }

        public async Task UpdateConditions()
        {
            //TODO: Ver cuando y como eliminar
            List<Condition> recordToInsert = new List<Condition>();
            var itemsCcb = await GetData<List<Condition>>(_servicesOption.ConditionsControllerCcb);
            var itemsCcm = await GetData<List<Condition>>(_servicesOption.ConditionsControllerCcm);
            //var itemsRest = await GetData<List<Condition>>(_servicesOption.ConditionsControllerResto);
            var items = new List<Condition>();
            items.AddRange(itemsCcb);
            items.AddRange(itemsCcm);
            //items.AddRange(itemsRest);

            var customerConditions = await _customerConditionSyncRepository.GetAllAsync();

            foreach (var item in items)
            {
                var customerCondition = customerConditions
                                            .Where(c => c.CODCTACTE == item.CODCTACTE
                                                && c.CODLIS == item.CODLIS
                                                && c.CODCONDI == item.CODCONDI)
                                            .ToList();
                if (customerCondition.Count == 0) recordToInsert.Add(item);
            }
            var itemsToSave = _mapper.Map<List<CustomerConditionSync>>(recordToInsert);
            itemsToSave.ForEach(item =>
            {
                item.Guid = Guid.NewGuid();
                item.CreatedAt = DateTime.Now;
                item.CreatedBy = Guid.Empty;
            });
            await _customerConditionSyncRepository.SaveRangeAsync(itemsToSave);
        }

        public async Task UpdateLists()
        {
            var items = await GetData<List<Lists>>(_servicesOption.ListDinController);
            var insertedCodes = (await _priceListSyncRepository.GetPriceListCodes()).ToList();
            var recordToInsert = GetRecordToInsert(items, insertedCodes, SyncCodeConstant.Price);
            var recordToRemove = insertedCodes.Except(items.Select(i => i.CODITM)).ToList();
            var itemsToSave = _mapper.Map<List<PriceListSync>>(recordToInsert);
            itemsToSave.ForEach(item =>
            {
                item.Guid = Guid.NewGuid();
                item.CreatedAt = DateTime.Now;
                item.CreatedBy = Guid.Empty;
            });
            await _priceListSyncRepository.SaveRangeAsync(itemsToSave);
            await _priceListSyncRepository.DeleteRowsRange(recordToRemove, SyncCodeConstant.Price);
        }

        #region Private Methods
        private List<T> GetRecordToInsert<T>(List<T> allRecords, List<string> insertedCodes, string prop) where T : new()
        {
            List<T> items = new List<T>();
            foreach (var record in allRecords)
            {
                if (!insertedCodes.Contains(record.GetType().GetProperty(prop).GetValue(record) as string))
                    items.Add(record);
            }
            return items;
        }
        private List<T> GetList<T>(List<T> fSet, List<T> sSet) where T : new()
        {
            List<T> items = new List<T>();
            items.AddRange(fSet);
            items.AddRange(sSet);
            return items;
        }
        private async Task<T> GetData<T>(string controller) where T : new()
        {
            var client = new RestClient(_servicesOption.Url);
            var request = new RestRequest(controller, Method.Get);
            var res = await client.ExecuteAsync<T>(request);
            if (res.Data == null) return JsonConvert.DeserializeObject<T>(res.Content);
            return res.Data;
        }
        #endregion
    }
}
