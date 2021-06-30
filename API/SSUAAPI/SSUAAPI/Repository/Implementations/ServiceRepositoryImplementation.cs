using System;
using System.Collections.Generic;
using System.Linq;
using SSUAAPI.Model;

namespace SSUAAPI.Repository.Implementations
{
    public class ServiceRepositoryImplementation : IServiceRepository
    { 
            private AppDbContext _context;

        public ServiceRepositoryImplementation(AppDbContext context)
        {
            _context = context;
        }


        public List<Service> FindAll()
        {
            return _context.Services.ToList();
        }

        public Service FindById(int id)
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
            if (!Exists(service.Id)) return null;

            var result = _context.Services.SingleOrDefault(s => s.Id.Equals(service.Id));

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

        public void Delete(int id)
        {
            var result = _context.Services.SingleOrDefault(s => s.Id.Equals(id));
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

        public void DeleteMaintenance(String name)
        {
            var result = _context.Services.SingleOrDefault(s => s.Name.Equals(name));
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

        public bool Exists(int id)
        {
            return _context.Services.Any(s => s.Id.Equals(id));
        }

    }
}
