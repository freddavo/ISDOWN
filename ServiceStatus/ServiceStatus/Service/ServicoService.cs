using System;
using System.Collections.Generic;
using ServiceStatus.Model;
namespace ServiceStatus.Service
{
    public interface ServicoService
    {
        Servico Create(Servico service);
        Servico FindById(long id);
        List<Servico> FindAll();
        Servico Update(Servico service);
        void Delete(long id);
    }
}
