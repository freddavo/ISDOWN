using System;
namespace Daemon
{
    public class Servico1
    {

        public string Maintenance { get; set; }
        public string Tempo { get; set; }

        public Servico1(string maintenance, string tempo)
        {
            Maintenance = maintenance;
            Tempo = tempo;
        }
    }
}
