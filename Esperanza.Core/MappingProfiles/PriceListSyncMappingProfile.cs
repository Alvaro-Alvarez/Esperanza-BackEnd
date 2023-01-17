using AutoMapper;
using Esperanza.Core.Models.Services;
using Esperanza.Core.Models.Sync;

namespace Esperanza.Core.MappingProfiles
{
    public class PriceListSyncMappingProfile : Profile
    {
        public PriceListSyncMappingProfile()
        {
            CreateMap<PriceListSync, Lists>();
            CreateMap<Lists, PriceListSync>();
        }
    }
}
