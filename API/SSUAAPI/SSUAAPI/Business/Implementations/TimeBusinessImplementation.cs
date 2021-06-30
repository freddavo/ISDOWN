using System;
using System.Collections.Generic;
using SSUAAPI.Model;
using SSUAAPI.Repository;

namespace SSUAAPI.Business.Implementations
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

        public Time FindById(int id)
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

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
