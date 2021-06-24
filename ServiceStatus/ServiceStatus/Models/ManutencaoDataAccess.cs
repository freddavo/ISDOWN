using System.Collections.Generic;
using System.Linq;
using ServiceStatus.Models;
namespace ServiceStatus.Controllers
{

    public class ManutencaoDataAccess
    {
        isdownContext db = new isdownContext();

        public IEnumerable<Manutencao> GetManutencao()
        {
            return db.Manutencaos.ToList();
        }
    }
}


