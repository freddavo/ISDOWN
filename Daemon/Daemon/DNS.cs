using System;
namespace Daemon
{
    public class DNS
    {
        public string Name { get; set; }
        public string Status { get; set; }

        public DNS(string name, string status)
        {
            Name = name;
            Status = status;
        }
    }
}
