using AutoMapper;
using Esperanza.Core.Models.Services;
using Esperanza.Core.Models.Sync;

namespace Esperanza.Core.MappingProfiles
{
    public class CustomerSyncMappingProfile : Profile
    {
        public CustomerSyncMappingProfile()
        {
            CreateMap<CustomerSync, CtaCte>();
            CreateMap<CtaCte, CustomerSync>();
        }
    }
}
