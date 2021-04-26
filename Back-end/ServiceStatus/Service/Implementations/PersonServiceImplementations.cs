using System;
using System.Collections.Generic;
using ServiceStatus.Model;
using ServiceStatus.Repository;

namespace ServiceStatus.Service.Implementations
{
    public class PersonServiceImplementations : PersonService
    {
        private readonly PersonRepository _repository;

        public PersonServiceImplementations(PersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
