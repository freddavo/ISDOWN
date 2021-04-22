using System;
using System.Collections.Generic;
using System.Linq;

using ServiceStatus.Model;
using ServiceStatus.Model.Context;

namespace ServiceStatus.Service.Implementations
{
    public class ServicoServiceImplementation : ServicoService
    {

        private MySQLContext _context;

        public ServicoServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        //Create a Service
        public Servico Create(Servico service)
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


        //List all Services
        public List<Servico> FindAll()
        {
            return _context.Servicos.ToList();
        }

        //Find a Service by ID
        public Servico FindById(long id)
        {
            return _context.Servicos.SingleOrDefault(s => s.Id.Equals(id));
        }

        //Update services
        public Servico Update(Servico service)
        {
            if (!Exists(service.Id)) return new Servico();

            var result = _context.Servicos.SingleOrDefault(s => s.Id.Equals(service.Id));

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

        //Delete a Service
        public void Delete(long id)
        {
            var result = _context.Servicos.SingleOrDefault(s => s.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Servicos.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        //Checks if a service exists by his ID
        private bool Exists(long id)
        {
            return _context.Servicos.Any(s => s.Id.Equals(id));
        }
    }
}
