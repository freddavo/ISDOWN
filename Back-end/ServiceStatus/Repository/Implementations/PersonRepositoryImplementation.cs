using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStatus.Model;
using ServiceStatus.Model.Context;

namespace ServiceStatus.Repository.Implementations
{
    public class PersonRepositoryImplementation : PersonRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person service)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person FindById(long id)
        {
            return _context.People.SingleOrDefault(s => s.Id.Equals(id));
        }

        public Person Update(Person service)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }
    }
}
