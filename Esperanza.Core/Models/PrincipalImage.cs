﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esperanza.Core.Models
{
    public class PrincipalImage : Entity
    {
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string FullName { get; set; }
        public string Extension { get; set; }
    }
}
