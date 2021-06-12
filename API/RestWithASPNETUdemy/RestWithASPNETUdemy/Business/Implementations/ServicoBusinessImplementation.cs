using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Implementations;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class ServicoBusinessImplementation : IServicoBusiness
    {
        //Já não acede diretamente, agora o Business trata disso
        private readonly IServicoRepository _repository;

        //private volatile int count;

        public ServicoBusinessImplementation(IServicoRepository repository)
        {
            _repository = repository;
        }


        public List<Servico> FindAll()
        {
            return _repository.FindAll();
        }

        public Servico FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Servico Create(Servico servico)
        {
            return _repository.Create(servico);
        }

        public Servico Update(Servico servico)
        {
            return _repository.Update(servico);
        }

        public void Delete(long id)
        {
           _repository.Delete(id);
        }
    }
}
