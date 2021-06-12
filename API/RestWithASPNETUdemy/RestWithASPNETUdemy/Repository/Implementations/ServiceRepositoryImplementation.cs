using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class ServiceRepositoryImplementation : IServiceRepository
    {
        private MySQLContext _context;
        //private volatile int count;

        public ServiceRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }


        public List<Service> FindAll()
        {
            return _context.Services.ToList();
        }

        public Service FindById(long id)
        {
            return _context.Services.SingleOrDefault(s => s.Id.Equals(id));
        }

        public Service Create(Service service)
        {
            try
            {
                _context.Add(service);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return service;
        }

        public Service Update(Service service)
        {
            //return new Person();
            if (!Exists(service.Id)) return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(service.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(service);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return service;
        }

        public void Delete(long id)
        {
            var result = _context.Services.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Services.Remove(result);
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
            return _context.Services.Any(p => p.Id.Equals(id));
        }

    }
}
