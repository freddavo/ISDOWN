using System;
using System.Collections.Generic;
using System.Linq;
using SSUAAPI.Model;

namespace SSUAAPI.Repository.Implementations
{
    public class TimeRepositoryImplementation : ITimeRepository
    {
        private AppDbContext _context;

        public TimeRepositoryImplementation(AppDbContext context)
        {
            _context = context;
        }


        public List<Time> FindAll()
        {
            return _context.Times.ToList();
        }

        public Time FindById(int id)
        {
            return _context.Times.SingleOrDefault(t => t.Id.Equals(id));
        }

        public Time Create(Time time)
        {
            try
            {
                _context.Add(time);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return time;
        }

        public Time Update(Time time)
        {
            if (!Exists(time.Id)) return null;

            var result = _context.Times.SingleOrDefault(t => t.Id.Equals(time.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(time);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return time;
        }

        public void Delete(int id)
        {
            var result = _context.Times.SingleOrDefault(t => t.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Times.Remove(result);
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
            return _context.Times.Any(t => t.Id.Equals(id));
        }

    }
}
