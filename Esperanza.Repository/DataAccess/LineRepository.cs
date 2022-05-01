using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;

namespace Esperanza.Repository.DataAccess
{
    public class LineRepository : GenericRepository<Line>, IGenericRepository<Line>
    {
        public LineRepository(IConnectionBuilder connectionBuilder) : base(Table.Line, connectionBuilder)
        {

        }
    }
}
