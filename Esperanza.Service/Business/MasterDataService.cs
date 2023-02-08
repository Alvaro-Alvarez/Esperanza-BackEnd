using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;

namespace Esperanza.Service.Business
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IGenericRepository<DocumentType> DocumentTypeRepository;
        private readonly IGenericRepository<Sex> SexRepository;
        private readonly IGenericRepository<UserRole> UserRoleRepository;
        private readonly IGenericRepository<PageType> PageTypeRepository;

        public MasterDataService(
            IGenericRepository<DocumentType> documentTypeRepository,
            IGenericRepository<Sex> sexRepository,
            IGenericRepository<UserRole> userRoleRepository,
            IGenericRepository<PageType> pageTypeRepository
            )
        {
            DocumentTypeRepository = documentTypeRepository;
            SexRepository = sexRepository;
            UserRoleRepository = userRoleRepository;
            PageTypeRepository = pageTypeRepository;
        }

        public async Task<List<DocumentType>> GetAllTypesOfDocumentsAsync()
        {
            return (await DocumentTypeRepository.GetAllAsync()).ToList();
        }

        public async Task<List<Sex>> GetAllSexsAsync()
        {
            return (await SexRepository.GetAllAsync()).ToList();
        }

        public async Task<List<UserRole>> GetAllUserRolesAsync()
        {
            return (await UserRoleRepository.GetAllAsync()).ToList();
        }

        public async Task<List<PageType>> GetPagesTypes()
        {
            return (await PageTypeRepository.GetAllAsync()).ToList();
        }
    }
}
