using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServiceStatus.Model.Base;
using ServiceStatus.Model.Context;

namespace ServiceStatus.Repository.Generic
{
    public class GenericRepository<T> : Repository<T> where T : BaseEntity
    {

        private readonly MySQLContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }   
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(s => s.Id.Equals(id));
        }

        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(s => s.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            //caso contrário
            return null;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(s => s.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
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
            return dataset.Any(s => s.Id.Equals(id));
        }
    }
}
