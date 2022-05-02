using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Service.Helpers;

namespace Esperanza.Service.Business
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository UserRepository;
        private readonly IPersonService PersonService;

        public AppUserService(
            IAppUserRepository userRepository,
            IPersonService personService)
        {
            UserRepository = userRepository;
            PersonService = personService;
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return (await UserRepository.GetAllAsync()).ToList();
        }

        public async Task<AppUser> GetByGuidAsync(string userGuid)
        {
            var user = await UserRepository.GetUserAsync(new Guid(userGuid));
            user.Person = await PersonService.GetByGuidAsync(userGuid);
            return user;
        }

        public async Task InsertAsync(AppUser user, string userGuid)
        {
            Guid creatorGuid = string.IsNullOrEmpty(userGuid) ? Guid.NewGuid() : new Guid(userGuid);
            //TODO: Encryptar contraseña
            EntityHelper.InitEntity(user, creatorGuid);
            Person person = await PersonService.InsertAsync(new Person(), user.Guid.Value);
            if (string.IsNullOrEmpty(userGuid))
            {
                user.CreatedBy = user.Guid.Value;
                user.UpdatedBy = user.Guid.Value;
            }
            user.PersonGuid = person.Guid.Value;
            await UserRepository.InsertAsync(user);
        }

        public async Task UpdateAsync(AppUser user, string userGuid)
        {
            EntityHelper.ModifyEntity(user, new Guid(userGuid));
            await UserRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(string userGuid, string updaterUserGuid)
        {
            var user = await UserRepository.GetAsync(userGuid);
            EntityHelper.ModifyEntity(user, new Guid(updaterUserGuid), delete: true);
            await UserRepository.UpdateAsync(user);
        }
    }
}
