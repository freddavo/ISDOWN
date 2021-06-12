
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public interface IServiceRepository
    {
        Service Create(Service service);
        Service FindById(long id);
        List<Service> FindAll();
        Service Update(Service service);
        void Delete(long id);
        bool Exists(long id);
    }
}
