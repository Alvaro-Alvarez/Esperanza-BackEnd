using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Service.Helpers;

namespace Esperanza.Service.Business
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository PersonRepository;
        private readonly IPhoneService PhoneService;

        public PersonService(
            IPersonRepository personRepository,
            IPhoneService phoneService)
        {
            PersonRepository = personRepository;
            PhoneService = phoneService;
        }

        public async Task<Person> GetByGuidAsync(string personGuid)
        {
            return await PersonRepository.GetFullPerson(new Guid(personGuid));
        }

        public async Task<Person> InsertAsync(Person person, Guid userGuid)
        {
            //Phone phone = person.Phone != null ? person.Phone : new Phone();
            Phone phone = await PhoneService.InsertAsync(person.Phone != null ? person.Phone : new Phone(), userGuid);
            EntityHelper.InitEntity(person, userGuid);
            person.PhoneGuid = phone.Guid.Value;
            await PersonRepository.InsertAsync(person);
            return person;
        }

        public async Task UpdateAsync(Person person, string userGuid)
        {
            EntityHelper.ModifyEntity(person, new Guid(userGuid));
            await PhoneService.UpdateAsync(person.Phone, userGuid);
            await PersonRepository.UpdateAsync(person);
        }

        public async Task DeleteAsync(string personGuid, string updaterUserGuid)
        {
            var person = await PersonRepository.GetAsync(personGuid);
            EntityHelper.ModifyEntity(person, new Guid(updaterUserGuid), delete: true);
            await PersonRepository.UpdateAsync(person);
        }
    }
}
