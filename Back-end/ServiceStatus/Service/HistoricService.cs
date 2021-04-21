using System;
using ServiceStatus.Model;

namespace ServiceStatus.Service
{
    public interface HistoricService
    {
        Historic Create(Historic service);
        Historic FindServiceById(long id);
        Historic Update(Historic service);
        void Delete(long id);
    }
}
