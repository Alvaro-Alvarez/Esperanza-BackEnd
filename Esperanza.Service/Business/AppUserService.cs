﻿using Esperanza.Core.Constants;
using Esperanza.Core.Exceptions;
using Esperanza.Core.Helpers;
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
        private readonly IBasApiService BasApiService;

        public AppUserService(
            IAppUserRepository userRepository,
            IPersonService personService,
            IBasApiService basApiService)
        {
            UserRepository = userRepository;
            PersonService = personService;
            BasApiService = basApiService;
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return (await UserRepository.GetAllAsync()).ToList();
        }

        public async Task<List<AppUser>> GetAllFull()
        {
            return await UserRepository.GetAllFull();
        }

        public async Task<AppUser> GetByGuidAsync(string userGuid)
        {
            var user = await UserRepository.GetUserAsync(new Guid(userGuid));
            user.Person = await PersonService.GetByGuidAsync(user.PersonGuid.ToString());
            return user;
        }

        public async Task InsertAsync(AppUser user, string userGuid)
        {
            if (await UserRepository.Exist(user.Email, user.BasClientCode)) throw new BusinessException(Core.Enums.ErrorCode.ClientCodeFound);
            Guid creatorGuid = string.IsNullOrEmpty(userGuid) ? Guid.NewGuid() : new Guid(userGuid);
            EntityHelper.InitEntity(user, creatorGuid);
            user.Pass = HashHelper.HashPassword(user.Guid.ToString(), user.Pass);
            user.RoleGuid = user.RoleGuid != null ? user.RoleGuid.Value : new Guid(RoleConstant.Client);
            user.Enabled = true;
            if (user.RoleGuid.Value.ToString().ToLower() == RoleConstant.Client.ToLower())
            {
                var userBas = await BasApiService.GetClientBas(user.BasClientCode);
                if (userBas == null || string.IsNullOrEmpty(userBas.Codigo)) throw new BusinessException(Core.Enums.ErrorCode.ClientCodeNotFound);
                if (!userBas.NumeroIdentificacionImpositiva.Equals(user.Person.Cuit)) throw new BusinessException(Core.Enums.ErrorCode.InvalidCuit);
                user.CanCCB = userBas.CondicionVentaBalanceado.Equals("CCB");
                user.CanCCM = userBas.CondicionVentaMedicamentos.Equals("CCM");
            }
            Person person = await PersonService.InsertAsync(user.Person, user.Guid.Value);
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
            await PersonService.UpdateAsync(user.Person, userGuid);
        }

        public async Task DeleteAsync(string userGuid, string updaterUserGuid)
        {
            var user = await UserRepository.GetAsync(userGuid);
            EntityHelper.ModifyEntity(user, new Guid(updaterUserGuid), delete: true);
            await UserRepository.UpdateAsync(user);
        }
    }
}
