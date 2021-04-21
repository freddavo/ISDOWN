using System;
using System.Collections.Generic;
using System.Threading;
using ServiceStatus.Model;
namespace ServiceStatus.Service.Implementations
{
    public class ServicoServiceImplementation : ServicoService
    {

        private volatile int count;

        public Servico Create(Servico service)
        {
            return service;
        }

        public void Delete(long id)
        {
            //não retorna nada por enquanto
        }

        public List<Servico> FindAll()
        {
            List<Servico> services = new List<Servico>();
            for (int i = 0; i < 10; i++)
            {
                Servico service = MockService(i);
                services.Add(service);

            }
            return services;
        }

        public Servico FindById(long id)
        {
            return new Servico
            {
                Id = 1,
                Name = "PACO",
                Status = "OK",
            };
        }

        public Servico Update(Servico service)
        {
            //no futuro, ir a base de dados e retornar o serviço updated
            return service;
        }

        private Servico MockService(int i)
        {
            return new Servico
            {
                Id = i,
                Name = "Service Name" + i,
                Status = "OK | NOT OK",
            };
        }

        private object IncrementGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
