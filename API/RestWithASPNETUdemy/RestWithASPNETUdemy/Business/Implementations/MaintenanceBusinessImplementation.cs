using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Implementations;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class MaintenanceBusinessImplementation : IMaintenanceBusiness
    {
        //Já não acede diretamente, agora o Business trata disso
        private readonly IMaintenanceRepository _repository;

        //private volatile int count;
        public MaintenanceBusinessImplementation(IMaintenanceRepository repository)
        {
            _repository = repository;
        }


        public List<Maintenance> FindAll()
        {
            return _repository.FindAll();
        }

        public Maintenance FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Maintenance Create(Maintenance maintenance)
        {
            return _repository.Create(maintenance);
        }

        public Maintenance Update(Maintenance maintenance)
        {
            return _repository.Update(maintenance);
        }

        public void Delete(long id)
        {
           _repository.Delete(id);
        }
    }
}
