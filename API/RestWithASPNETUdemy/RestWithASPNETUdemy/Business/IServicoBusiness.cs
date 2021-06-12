
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public interface IServicoBusiness
    {
        Servico Create(Servico servico);
        Servico FindById(long id);
        List<Servico> FindAll();
        Servico Update(Servico servico);
        void Delete(long id);
    }
}
