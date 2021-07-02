using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceStatus.Models
{
    public partial class Historico
    {
        public string NomeServico { get; set; }
        public string DataFalha { get; set; }
        public string Resolvido { get; set; }
    }
}
