using AutoMapper;
using Esperanza.Core.Constants;
using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models.Options;
using Esperanza.Core.Models.Services;
using Esperanza.Core.Models.Sync;
using Esperanza.Core.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace Esperanza.Service.Business
{
    public class ItemUpdateService : IItemUpdateService
    {
        private readonly ServicesOption _servicesOption;
        private readonly ServiceUpdateOptions _serviceUpdateOptions;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<PropductSync> _propductSyncRepository;
        private readonly IGenericRepository<CustomerSync> _customerSyncRepository;
        private readonly ICustomerConditionSyncRepository _customerConditionSyncRepository;
        private readonly IGenericRepository<PriceListSync> _priceListSyncRepository;

        public ItemUpdateService(
            IOptions<ServicesOption> servicesOption,
            IOptions<ServiceUpdateOptions> serviceUpdateOptions,
            IMapper mapper,
            IGenericRepository<PropductSync> propductSyncRepository,
            IGenericRepository<CustomerSync> customerSyncRepository,
            ICustomerConditionSyncRepository customerConditionSyncRepository,
            IGenericRepository<PriceListSync> priceListSyncRepository
            )
        {
            _servicesOption = servicesOption.Value;
            _serviceUpdateOptions = serviceUpdateOptions.Value;
            _propductSyncRepository = propductSyncRepository;
            _customerSyncRepository = customerSyncRepository;
            _customerConditionSyncRepository = customerConditionSyncRepository;
            _priceListSyncRepository = priceListSyncRepository;
            _mapper = mapper;
        }

        public async Task UpdateProducts()
        {
            var endOfItems = false;
            var start = _serviceUpdateOptions.StartPagination;
            var items = new List<Item>();
            while (!endOfItems)
            {
                var setItems = await GetData<List<Item>>($"{_servicesOption.ItemsController}&PAGINA={_serviceUpdateOptions.ProductRange}&DESDE={start}");
                endOfItems = setItems == null || setItems.Count() == 0;
                if (!endOfItems) items.AddRange(setItems);
                start += _serviceUpdateOptions.ProductRange;
            }
            var insertedCodes = (await _propductSyncRepository.GetProductCodes()).ToList();
            var recordToInsert = GetRecordToInsert(items, insertedCodes, SyncCodeConstant.Product);
            var recordToUpdate = GetProductsToUpdate(items, insertedCodes);
            var recordToRemove = insertedCodes.Except(items.Select(i => i.CODIGO)).ToList();
            var itemsToUpdate = _mapper.Map<List<PropductSync>>(recordToUpdate);
            var itemsToSave = _mapper.Map<List<PropductSync>>(recordToInsert);
            itemsToSave.ForEach(item =>
            {
                item.Guid = Guid.NewGuid();
                item.CreatedAt = DateTime.Now;
                item.CreatedBy = Guid.Empty;
            });
            await _propductSyncRepository.SaveRangeAsync(itemsToSave);
            await _propductSyncRepository.UpdateRangeAsync(itemsToUpdate);
            await _propductSyncRepository.DeleteRowsRange(recordToRemove, SyncCodeConstant.Product);
            /*LLama a endpoint para avisar que todos los productos fueron actualizados*/
            await GetData<object>(_servicesOption.NotifyUpdateController);
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
            var startCCM = _serviceUpdateOptions.StartPagination;
            var startCCB = _serviceUpdateOptions.StartPagination;
            var startRESTO = _serviceUpdateOptions.StartPagination;
            var endOfItemsCCM = false;
            var endOfItemsCCB = false;
            var endOfItemsRESTO = false;
            var items = new List<Condition>();
            var recordToInsert = new List<Condition>();

            while (!endOfItemsCCM)
            {
                var itemsCcm = await GetData<List<Condition>>($"{_servicesOption.ConditionsControllerCcm}&PAGINA={_serviceUpdateOptions.ConditionsRange}&DESDE={startCCM}");
                endOfItemsCCM = itemsCcm == null || itemsCcm.Count() == 0;
                if (!endOfItemsCCM) items.AddRange(itemsCcm);
                startCCM += _serviceUpdateOptions.ConditionsRange;
            }
            while (!endOfItemsCCB)
            {
                var itemsCcb = await GetData<List<Condition>>($"{_servicesOption.ConditionsControllerCcb}&PAGINA={_serviceUpdateOptions.ConditionsRange}&DESDE={startCCB}");
                endOfItemsCCB = itemsCcb == null || itemsCcb.Count() == 0;
                if (!endOfItemsCCB) items.AddRange(itemsCcb);
                startCCB += _serviceUpdateOptions.ConditionsRange;
            }
            while (!endOfItemsRESTO)
            {
                var itemsRest = await GetData<List<Condition>>($"{_servicesOption.ConditionsControllerResto}&PAGINA={_serviceUpdateOptions.ConditionsRange}&DESDE={startRESTO}");
                endOfItemsRESTO = itemsRest == null || itemsRest.Count() == 0;
                if (!endOfItemsRESTO) items.AddRange(itemsRest);
                startRESTO += _serviceUpdateOptions.ConditionsRange;
            }

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

        public async Task RestartServices(string password)
        {
            if (password != _serviceUpdateOptions.RestarPassword) throw new Exception("La contraseña es inválida");
            await _propductSyncRepository.DeleteAll(PropductSync.DeleteAll);
            await _propductSyncRepository.DeleteAll(CustomerSync.DeleteAll);
            await _propductSyncRepository.DeleteAll(CustomerConditionSync.DeleteAll);
            await _propductSyncRepository.DeleteAll(PriceListSync.DeleteAll);
            await UpdateProducts();
            await UpdateCtaCte();
            await UpdateConditions();
            await UpdateLists();
        }

        #region Private Methods
        private List<Item> GetProductsToUpdate(List<Item> items, List<string> insertedCodes)
        {
            var newItems = new List<Item>();
            foreach (var item in items)
            {
                if (item.ACTUALIZADO == "1")
                {
                    if (insertedCodes.Contains(item.CODIGO)) newItems.Add(item);
                }
            }
            return newItems;

        }
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
