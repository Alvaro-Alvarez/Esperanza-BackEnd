using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(bool withDelete = false);
        Task<IEnumerable<T>> GetByRangeIds(string query, string adId);
        Task DeleteRowAsync(string id);
        Task DeleteIntermediate(string idAd, string query);
        Task<T> GetAsync(string id);
        Task<int> SaveRangeAsync(IEnumerable<T> list);
        Task UpdateAsync(T t);
        Task InsertAsync(T t);
        Task<int> GetLastId();
    }
}
