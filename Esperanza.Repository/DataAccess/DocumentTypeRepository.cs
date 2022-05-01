using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class DocumentTypeRepository : GenericRepository<DocumentType>, IGenericRepository<DocumentType>
    {
        public DocumentTypeRepository(IConnectionBuilder connectionBuilder) : base(Table.DocumentType, connectionBuilder)
        {

        }
    }
}
