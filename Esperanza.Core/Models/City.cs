using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Models
{
    public class City : Entity
    {
        public string Name { get; set; }
        public Guid CountryGuid { get; set; }
    }
}
