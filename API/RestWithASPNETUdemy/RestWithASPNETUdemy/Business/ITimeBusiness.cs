
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public interface ITimeBusiness
    {
        Time Create(Time time);
        Time FindById(long id);
        List<Time> FindAll();
        Time Update(Time time);
        void Delete(long id);
    }
}
