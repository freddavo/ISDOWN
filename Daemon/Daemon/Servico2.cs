using System;
namespace Daemon
{
    public class Servico2
    {
        public string Name { get; set; }
        public string Tempo { get; set; }

        public Servico2(string name, string tempo)
        {
            Name = name;
            Tempo = tempo;
        }
    }
}
