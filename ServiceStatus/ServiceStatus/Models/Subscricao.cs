using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceStatus.Models
{
    public partial class Subscricao
    {
        public string IdPessoa { get; set; }
        public string IdServico { get; set; }

        //public virtual Pessoa IdPessoaNavigation { get; set; }
        //public virtual Servico IdServicoNavigation { get; set; }
    }
}
