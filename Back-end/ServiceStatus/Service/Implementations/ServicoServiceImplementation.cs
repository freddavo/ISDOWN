using System;
using System.Collections.Generic;
using System.Linq;

using ServiceStatus.Model;
using ServiceStatus.Model.Context;

namespace ServiceStatus.Service.Implementations
{
    public class ServicoServiceImplementation : ServicoService
    {

        private MySQLContext _context;

        public ServicoServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        //Create a Service
        public Servico Create(Servico service)
        {
            return service;
        }


        //List all Services
        public List<Servico> FindAll()
        {
            return _context.Servicos.ToList();
        }

        //Find a Service by ID
        public Servico FindById(long id)
        {
            return new Servico
            {
                Id = 1,
                Name = "PACO",
                Status = "OK",
            };
        }

        //Update services
        public Servico Update(Servico service)
        {
            //no futuro, ir a base de dados e retornar o serviço updated
            return service;
        }

        //Delete a Service
        public void Delete(long id)
        {
            //não retorna nada por enquanto
        }
    }
}
