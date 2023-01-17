using AutoMapper;
using Esperanza.Core.Models.Services;
using Esperanza.Core.Models.Sync;

namespace Esperanza.Core.MappingProfiles
{
    public class PropductSyncMappingProfile : Profile
    {
        public PropductSyncMappingProfile()
        {
            CreateMap<PropductSync, Item>();
            CreateMap<Item, PropductSync>();
        }
    }
}
