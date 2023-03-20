namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(bool withDelete = true);
        Task<IEnumerable<T>> GetByRangeIds(string query, string adId);
        Task DeleteRowAsync(string id);
        Task DeleteIntermediate(string idAd, string query);
        Task<T> GetAsync(string id);
        Task<int> SaveRangeAsync(IEnumerable<T> list);
        Task UpdateAsync(T t);
        Task UpdateRangeAsync(List<T> ts);
        Task InsertAsync(T t);
        Task<int> GetLastId();
        Task<T> GetByName(string name);
        Task<IEnumerable<T>> GetRangeByName(List<string> names);

        Task DeleteRowsRange(List<string> codes, string column);
        Task<IEnumerable<string>> GetProductCodes();
        Task<IEnumerable<string>> GetCustomerCodes();
        Task<IEnumerable<string>> GetPriceListCodes();
        Task<IEnumerable<string>> GetTransportCodes();
        Task SoftDelete(string id);
        Task DeleteAll(string query);
    }
}
