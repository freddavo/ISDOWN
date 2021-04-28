using System;
using System.Collections.Generic;
using ServiceStatus.Model;
namespace ServiceStatus.Repository
{
    //apagar
    public interface PersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Exists(long id);
    }
}
