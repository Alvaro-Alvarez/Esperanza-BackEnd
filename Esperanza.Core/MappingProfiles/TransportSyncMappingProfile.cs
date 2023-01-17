using AutoMapper;
using Esperanza.Core.Models.Services;
using Esperanza.Core.Models.Sync;

namespace Esperanza.Core.MappingProfiles
{
    public class TransportSyncMappingProfile : Profile
    {
        public TransportSyncMappingProfile()
        {
            CreateMap<TransportSync, Transports>();
            CreateMap<Transports, TransportSync>();
        }
    }
}
