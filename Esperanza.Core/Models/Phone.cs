using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Models
{
    public class Phone : Entity
    {
        public string CountryCode { get; set; }
        public string CityCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
