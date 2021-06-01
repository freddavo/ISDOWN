using System.Collections.Generic;
using System.Linq;
using ServiceStatus.Models;
namespace ServiceStatus.Controllers
{
    
    public class ServiceDataAccess
    {
        isdownContext db = new isdownContext();

        public IEnumerable<Servico> GetServico()
        { 
          return db.Servicos.ToList();
        }  
    }
}
    

