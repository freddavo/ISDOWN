using System;
namespace Daemon
{
    public class Servico1
    {
        public string Name { get; set; }
        public string Maintenance { get; set; }
        public string Delete { get; set; }

        public Servico1(string name, string maintenance, string delete)
        {
            Name = name;
            Maintenance = maintenance;
            Delete = delete;
        }
    }
}
