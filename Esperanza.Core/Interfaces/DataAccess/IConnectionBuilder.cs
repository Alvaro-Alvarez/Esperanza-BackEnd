using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Interfaces.DataAccess
{
    public interface IConnectionBuilder
    {
        SqlConnection GetConnection();
    }
}
