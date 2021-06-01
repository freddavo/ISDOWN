using System.Collections.Generic;
using System.Linq;
using ServiceStatus.Models;
namespace ServiceStatus.Controllers
{

    public class DnsDataAccess
    {
        isdownContext db = new isdownContext();

        public IEnumerable<Dns> GetDns()
        {
            return db.Dns.ToList();
        }
    }
}


