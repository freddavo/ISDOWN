using System;
using System.Collections.Generic;
using System.Linq;

using ServiceStatus.Model;
using ServiceStatus.Model.Context;
using ServiceStatus.Repository;

namespace ServiceStatus.Service.Implementations
{
    public class ServicoServiceImplementation : ServicoService
    {
         
        //Deixou-se de aceder diretamente ao context da DB e agora usa-se o Repository
        private readonly ServicoRepository _repository;

        public ServicoServiceImplementation(ServicoRepository repository)
        {
            _repository = repository;
        }

        //Create a Service
        public Servico Create(Servico service)
        {
            return _repository.Create(service);
        }


        //List all Services
        public List<Servico> FindAll()
        {
            return _repository.FindAll();
        }

        //Find a Service by ID
        public Servico FindById(long id)
        {
            return _repository.FindById(id);
        }

        //Update services
        public Servico Update(Servico service)
        {
            return _repository.Update(service);
        }

        //Delete a Service
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
} 