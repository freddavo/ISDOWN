using System;
using System.Collections.Generic;
using ServiceStatus.Model;
namespace ServiceStatus.Repository
{
    public interface ServicoRepository
    {
        Servico Create(Servico service);
        Servico FindById(long id);
        List<Servico> FindAll();
        Servico Update(Servico service);
        void Delete(long id);
        bool Exists(long id);
    }
}
