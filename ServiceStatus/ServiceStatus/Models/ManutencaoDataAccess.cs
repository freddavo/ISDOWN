using System.Collections.Generic;
using System.Linq;
using ServiceStatus.Models;
namespace ServiceStatus.Controllers
{

    public class AdminDataAccess
    {
        isdownContext db = new isdownContext();

        public IEnumerable<Admin> GetAdmin()
        {
            return db.Admins.ToList();
        }
    }
}


