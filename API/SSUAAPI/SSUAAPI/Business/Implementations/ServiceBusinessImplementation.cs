using System;
using System.Collections.Generic;
using SSUAAPI.Model;
using SSUAAPI.Repository;

namespace SSUAAPI.Business.Implementations
{
    public class ServiceBusinessImplementation : IServiceBusiness
    {
        //Já não acede diretamente, agora o Business trata disso
        private readonly IServiceRepository _repository;

        public ServiceBusinessImplementation(IServiceRepository repository)
        {
            _repository = repository;
        }


        public List<Service> FindAll()
        {
            return _repository.FindAll();
        }

        public Service FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Service Create(Service service)
        {
            return _repository.Create(service);
        }

        public Service Update(Service service)
        {
            return _repository.Update(service);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteMaintenance(String name)
        {
            _repository.DeleteMaintenance(name);
        }
    }
}
