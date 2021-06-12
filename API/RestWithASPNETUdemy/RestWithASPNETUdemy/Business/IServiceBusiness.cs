
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public interface IServiceBusiness
    {
        Service Create(Service service);
        Service FindById(long id);
        List<Service> FindAll();
        Service Update(Service service);
        void Delete(long id);
    }
}
