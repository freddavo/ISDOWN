using System;
using System.Collections.Generic;
using SSUAAPI.Model;

namespace SSUAAPI.Business
{
    public interface IServiceBusiness
    {
        Service Create(Service service);
        Service FindById(int id);
        List<Service> FindAll();
        Service Update(Service service);
        void Delete(int id);
        void DeleteMaintenance(String name);
    }
}
