using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Models
{
    public class Neighborhood : Entity
    {
        public string Name { get; set; }
        public Guid CityGuid { get; set; }
    }
}
