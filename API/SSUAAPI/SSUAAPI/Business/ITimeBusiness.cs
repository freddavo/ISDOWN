using System;
using System.Collections.Generic;
using SSUAAPI.Model;

namespace SSUAAPI.Business
{
    public interface ITimeBusiness
    {
        Time Create(Time time);
        Time FindById(int id);
        List<Time> FindAll();
        Time Update(Time time);
        void Delete(int id);
    }
}
