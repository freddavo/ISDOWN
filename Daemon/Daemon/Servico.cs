using System;
namespace Daemon
{
    public class Servico
    {

        public string Name { get; set; }
        public string HealthState { get; set; }
        public string Path { get; set; }

        public Servico(string name, string healthState, string path)
        {
            Name = name;
            HealthState = healthState;
            Path = path;
        }
    }
}
