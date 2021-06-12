using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Implementations;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        //Já não acede diretamente, agora o Business trata disso
        private readonly IPersonRepository _repository;

        //private volatile int count;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }


        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
           _repository.Delete(id);
        }


        /*private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }*/
    }
}
