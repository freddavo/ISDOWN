using System;
namespace Daemon
{
    public class Admin
    {
        public string Name { get; set; }
        public string HealthState { get; set; }
        public string Resolvido { get; set; }
        public string Tempo { get; set; }

        public Admin(string name, string healthState, string resolvido, string tempo)
        {
            Name = name;
            HealthState = healthState;
            Resolvido = resolvido;
            Tempo = tempo;
        }
    }
}
