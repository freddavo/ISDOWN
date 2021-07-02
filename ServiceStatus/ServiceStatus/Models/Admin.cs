using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceStatus.Models
{
    public partial class Admin
    {
        public string Name { get; set; }
        public string HealthState { get; set; }
        public string Tempo { get; set; }
    }
}
