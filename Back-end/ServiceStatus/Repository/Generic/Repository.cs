using System;
using System.Collections.Generic;
using ServiceStatus.Model.Base;

namespace ServiceStatus.Repository
{
    public interface Repository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}
