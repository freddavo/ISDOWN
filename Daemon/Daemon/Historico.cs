using System;
namespace Daemon
{
    public class Historico
    {
        public string NomeServico { get; set; }
        public string DataFalha { get; set; }
        public string Falha { get; set; }

        public Historico(string nomeServico, string dataFalha, string falha)
        {
            NomeServico = nomeServico;
            DataFalha = dataFalha;
            Falha = falha;
        }
    }
}
