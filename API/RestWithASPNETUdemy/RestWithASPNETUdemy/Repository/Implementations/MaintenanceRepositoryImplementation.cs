using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class MaintenanceRepositoryImplementation : IMaintenanceRepository
    {
        private MySQLContext _context;
        //private volatile int count;

        public MaintenanceRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }


        public List<Maintenance> FindAll()
        {
            return _context.Maintenances.ToList();
        }

        public Maintenance FindById(long id)
        {
            return _context.Maintenances.SingleOrDefault(m => m.Id.Equals(id));
        }

        public Maintenance Create(Maintenance maintenance)
        {
            try
            {
                _context.Add(maintenance);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return maintenance;
        }

        public Maintenance Update(Maintenance maintenance)
        {
            //return new Person();
            if (!Exists(maintenance.Id)) return null;

            var result = _context.Maintenances.SingleOrDefault(m => m.Id.Equals(maintenance.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(maintenance);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return maintenance;
        }

        public void Delete(long id)
        {
            var result = _context.Maintenances.SingleOrDefault(m => m.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Maintenances.Remove(result);
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
            return _context.Maintenances.Any(m => m.Id.Equals(id));
        }
    }
}
