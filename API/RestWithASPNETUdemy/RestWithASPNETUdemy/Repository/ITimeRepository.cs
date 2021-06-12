
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public interface ITimeRepository
    {
        Time Create(Time time);
        Time FindById(long id);
        List<Time> FindAll();
        Time Update(Time person);
        void Delete(long id);
        bool Exists(long id);
 
    }
}
