using AutoMapper;
using Esperanza.Core.Models.Services;
using Esperanza.Core.Models.Sync;

namespace Esperanza.Core.MappingProfiles
{
    public class CustomerConditionSyncMappingProfile : Profile
    {
        public CustomerConditionSyncMappingProfile()
        {
            CreateMap<CustomerConditionSync, Condition>();
            CreateMap<Condition, CustomerConditionSync>();
        }
    }
}
