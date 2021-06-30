using System;
using System.Collections.Generic;
using SSUAAPI.Model;

namespace SSUAAPI.Repository
{
    public interface ITimeRepository
    {
        Time Create(Time person);
        Time FindById(int id);
        List<Time> FindAll();
        Time Update(Time person);
        void Delete(int id);
        bool Exists(int id);
    }
}
