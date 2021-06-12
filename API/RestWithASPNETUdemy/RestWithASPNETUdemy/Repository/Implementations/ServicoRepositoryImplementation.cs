using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class ServicoRepositoryImplementation : IServicoRepository
    {
        private MySQLContext _context;
        //private volatile int count;

        public ServicoRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Servico> FindAll()
        {
            return _context.Servicos.ToList();
        }

        public Servico FindById(long id)
        {
            return _context.Servicos.SingleOrDefault(s => s.Id.Equals(id));
        }

        public Servico Create(Servico servico)
        {
            try
            {
                _context.Add(servico);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return servico;
        }

        public Servico Update(Servico servico)
        {
            //return new Person();
            if (!Exists(servico.Id)) return null;

            var result = _context.Servicos.SingleOrDefault(p => p.Id.Equals(servico.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(servico);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return servico;
        }

        public void Delete(long id)
        {
            var result = _context.Servicos.SingleOrDefault(p => p.Id.Equals(id));
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

        public bool Exists(long id)
        {
            return _context.Servicos.Any(p => p.Id.Equals(id));
        }
    }
}
