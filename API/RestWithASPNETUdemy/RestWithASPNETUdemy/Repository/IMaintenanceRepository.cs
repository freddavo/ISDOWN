
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public interface IMaintenanceRepository
    {
        Maintenance Create(Maintenance maintenance);
        Maintenance FindById(long id);
        List<Maintenance> FindAll();
        Maintenance Update(Maintenance person);
        void Delete(long id);
        bool Exists(long id);
 
    }
}
