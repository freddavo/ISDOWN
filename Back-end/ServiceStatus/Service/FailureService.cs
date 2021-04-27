using System;
using System.Collections.Generic;
using ServiceStatus.Model;

namespace ServiceStatus.Service
{
    public interface FailureService
    {
        Failure Create(Failure failure);
        Failure FindById(long id);
        List<Failure> FindAll();
        void Delete(long id);
    }
}
