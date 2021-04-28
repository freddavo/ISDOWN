using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStatus.Model;
using ServiceStatus.Model.Context;

namespace ServiceStatus.Repository.Implementations
{
    //apagar?
    public class FailureRepositoryImplementation : FailureRepository
    {

        private MySQLContext _context;

        public FailureRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Failure Create(Failure failure)
        {
            try
            {
                _context.Add(failure);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return failure;
        }

        public List<Failure> FindAll()
        {
            return _context.Failures.ToList();
        }

        public Failure FindById(long id)
        {
            return _context.Failures.SingleOrDefault(f => f.Id.Equals(id));
        }

        public void Delete(long id)
        {
            var result = _context.Failures.SingleOrDefault(f => f.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Failures.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
