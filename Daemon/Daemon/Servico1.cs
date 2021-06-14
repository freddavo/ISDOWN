using System;
namespace Daemon
{
    public class Servico1
    {
        public string Name { get; set; }
        public string Maintenance { get; set; }
        //public string Id { get; set; }

        public Servico1(string name, string maintenance/*, string id*/)
        {
            Name = name;
            Maintenance = maintenance;
            //Id = id;
        }
    }
}
