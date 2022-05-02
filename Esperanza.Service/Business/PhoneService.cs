using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Service.Helpers;

namespace Esperanza.Service.Business
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository PhoneRepository;

        public PhoneService(
            IPhoneRepository phoneRepository)
        {
            PhoneRepository = phoneRepository;
        }

        public async Task<Phone> InsertAsync(Phone phone, Guid userGuid)
        {
            EntityHelper.InitEntity(phone, userGuid);
            await PhoneRepository.InsertAsync(phone);
            return phone;
        }

        public async Task UpdateAsync(Phone phone, string userGuid)
        {
            EntityHelper.ModifyEntity(phone, new Guid(userGuid));
            await PhoneRepository.UpdateAsync(phone);
        }

        public async Task DeleteAsync(string guid, string updaterUserGuid)
        {
            var phone = await PhoneRepository.GetAsync(guid);
            EntityHelper.ModifyEntity(phone, new Guid(updaterUserGuid), delete: true);
            await PhoneRepository.UpdateAsync(phone);
        }
    }
}
