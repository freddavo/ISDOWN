﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceStatus.Models
{
    public partial class Historico
    {
        public string NomeServico { get; set; }
        public string DataFalha { get; set; }
        public string Falha { get; set; }

        public virtual Servico IdServicoNavigation { get; set; }
    }
}
