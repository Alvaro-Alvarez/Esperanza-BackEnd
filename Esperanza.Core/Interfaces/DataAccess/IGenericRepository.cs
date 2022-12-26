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
        Task InsertAsync(T t);
        Task<int> GetLastId();
        Task<T> GetByName(string name);
        Task<IEnumerable<T>> GetRangeByName(List<string> names);
    }
}
