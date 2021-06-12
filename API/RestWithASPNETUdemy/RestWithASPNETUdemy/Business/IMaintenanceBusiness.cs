
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public interface IMaintenanceBusiness
    {
        Maintenance Create(Maintenance maintenance);
        Maintenance FindById(long id);
        List<Maintenance> FindAll();
        Maintenance Update(Maintenance maintenance);
        void Delete(long id);
    }
}
