using System;
using System.Collections.Generic;
using SSUAAPI.Model;

namespace SSUAAPI.Repository
{
    public interface IServiceRepository
    {
        Service Create(Service service);
        Service FindById(int id);
        List<Service> FindAll();
        Service Update(Service service);
        void Delete(int id);
        bool Exists(int id);
        void DeleteMaintenance(String name);
    }
}
