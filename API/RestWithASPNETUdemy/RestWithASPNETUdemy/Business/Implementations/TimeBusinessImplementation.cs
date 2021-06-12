using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Implementations;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class TimeBusinessImplementation : ITimeBusiness
    {
        //Já não acede diretamente, agora o Business trata disso
        private readonly ITimeRepository _repository;

        //private volatile int count;

        public TimeBusinessImplementation(ITimeRepository repository)
        {
            _repository = repository;
        }


        public List<Time> FindAll()
        {
            return _repository.FindAll();
        }

        public Time FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Time Create(Time time)
        {
            return _repository.Create(time);
        }

        public Time Update(Time time)
        {
            return _repository.Update(time);
        }

        public void Delete(long id)
        {
           _repository.Delete(id);
        }
    }
}
