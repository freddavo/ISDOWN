
using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public interface IServicoRepository
    {
        Servico Create(Servico servico);
        Servico FindById(long id);
        List<Servico> FindAll();
        Servico Update(Servico servico);
        void Delete(long id);
        bool Exists(long id);
    }
}
