using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;

namespace Esperanza.Service.Business
{
    public class RoleService : IRoleService
    {
        private readonly IGenericRepository<UserRole> RoleRepository;

        public RoleService(IGenericRepository<UserRole> roleRepository)
        {
            RoleRepository = roleRepository;
        }

        public async Task<UserRole> GetById(string guid)
        {
            return await RoleRepository.GetAsync(guid);
        }
        public async Task Insert(UserRole role, string userId)
        {
            InitInsert(role, userId);
            await RoleRepository.InsertAsync(role);
        }
        public async Task Update(UserRole role, string userId)
        {
            InitUpdate(role, userId);
            await RoleRepository.UpdateAsync(role);
        }
        public async Task Delete(string guid, string userId)
        {
            var role = await RoleRepository.GetAsync(guid);
            InitUpdate(role, userId,  delete: true);
            await RoleRepository.UpdateAsync(role);
        }

        #region Private Methods
        private void InitInsert(UserRole role, string userId)
        {
            role.Guid = Guid.NewGuid();
            role.CreatedAt = DateTime.Now;
            role.UpdatedAt = DateTime.Now;
            role.CreatedBy = new Guid(userId);
            role.UpdatedBy = new Guid(userId);
            role.Deleted = false;
        }
        private void InitUpdate(UserRole role, string userId, bool delete = false)
        {
            role.UpdatedAt = DateTime.Now;
            role.UpdatedBy = new Guid(userId);
            if (delete) role.Deleted = true;
        }
        #endregion
    }
}
