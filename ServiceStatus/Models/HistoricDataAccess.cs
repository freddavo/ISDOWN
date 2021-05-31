using System.Collections.Generic;
using System.Linq;

namespace ServiceStatus.Models
{
    public class HistoricDataAccess
    {
        isdownContext db = new isdownContext();

        public IEnumerable<Historico> GetHistoric()
        {
            return db.Historicos.ToList();
        }
    }
}
