using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Implementations;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class ServiceBusinessImplementation : IServiceBusiness
    {
        //Já não acede diretamente, agora o Business trata disso
        private readonly IServiceRepository _repository;

        //private volatile int count;

        public ServiceBusinessImplementation(IServiceRepository repository)
        {
            _repository = repository;
        }


        public List<Service> FindAll()
        {
            return _repository.FindAll();
        }

        public Service FindById(long id)
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

        public void Delete(long id)
        {
           _repository.Delete(id);
        }
    }
}
