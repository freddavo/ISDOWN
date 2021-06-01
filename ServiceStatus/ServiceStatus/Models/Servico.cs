using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceStatus.Models
{
    public partial class Servico
    {
        public Servico()
        {

        }

        public string Name { get; set; }
        public string Health_State { get; set; }
        public string Path { get; set; }

        //public virtual ICollection<Historico> Historico { get; set; }
        //public virtual ICollection<Subscricao> Subscricaos { get; set; }
    }
}
