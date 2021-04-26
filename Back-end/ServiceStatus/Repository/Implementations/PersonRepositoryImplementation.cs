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

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person FindById(long id)
        {
            return _context.People.SingleOrDefault(s => s.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            //Check if a person exists in the database
            //If it does not, return a empty instance
            if (!Exists(person.Id)) return null;

            //Current status of the record in the database
            var result = _context.Servicos.SingleOrDefault(s => s.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.People.SingleOrDefault(s => s.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.People.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.People.Any(s => s.Id.Equals(id));
        }
    }
}
