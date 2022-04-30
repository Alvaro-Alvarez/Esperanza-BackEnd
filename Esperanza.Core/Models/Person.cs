using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Models
{
    public class Person : Entity
    {
        public Guid DocumentTypeGuid { get; set; }
        public Guid PhoneGuid { get; set; }
        public Guid SexGuid { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string DocumentNumber { get; set; }
    }
}
