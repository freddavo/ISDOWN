using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceStatus.Models
{
    public partial class Admin
    {
        public Admin()
        {

        }

        public string Name { get; set; }
        public string Health_State { get; set; }
        public string Resolvido { get; set; }
        public string Tempo { get; set; }

    }
}
