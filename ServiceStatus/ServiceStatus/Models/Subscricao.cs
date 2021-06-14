using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceStatus.Models
{
    public partial class Subscricao
    {
        public string Email { get; set; }
        public string NomeServico { get; set; }

        public virtual Servico NomeServicoNavigation { get; set; }
    }
}
