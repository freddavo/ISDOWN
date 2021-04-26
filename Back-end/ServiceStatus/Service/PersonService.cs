using System;
using System.Collections.Generic;
using ServiceStatus.Model;

namespace ServiceStatus.Service
{
    public interface PersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person service);
        void Delete(long id);
    }
}
