using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceStatus.Models
{
    public partial class Servico
    {
        public Servico()
        {
            //Subscricaos = new HashSet<Subscricao>();
        }

        public string Name { get; set; }
        public string HealthState { get; set; }
        public string Path { get; set; }
        public string Maintenance { get; set; }
        public string Tempo { get; set; }

        //public virtual ICollection<Subscricao> Subscricaos { get; set; }
    }
}
