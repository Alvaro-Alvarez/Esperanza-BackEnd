using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Models
{
    public class Address : Entity
    {
        public Guid CountryGuid { get; set; }
        public Guid CityGuid { get; set; }
        public Guid? NeighborhoodGuid { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string Floor { get; set; }
        public string Door { get; set; }
    }
}
