using System;
namespace Daemon
{
    public class Servico1
    {
        public string Name { get; set; }
        public string Maintenance { get; set; }
        //public string Tempo { get; set; }

        public Servico1(string name, string maintenance/*, string tempo*/)
        {
            Name = name;
            Maintenance = maintenance;
            //Tempo = tempo;
        }
    }
}
