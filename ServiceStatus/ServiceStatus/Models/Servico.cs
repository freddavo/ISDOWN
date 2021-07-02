using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceStatus.Models
{
    public partial class Servico
    {
        public string Name { get; set; }
        public string HealthState { get; set; }
        public string Path { get; set; }
        public string Tempo { get; set; }
    }
}
