using System;
using System.Collections.Generic;
using ServiceStatus.Model;
namespace ServiceStatus.Repository
{
    public interface PersonRepository
    {
        Person Create(Person service);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person service);
        void Delete(long id);
        bool Exists(long id);
    }
}
