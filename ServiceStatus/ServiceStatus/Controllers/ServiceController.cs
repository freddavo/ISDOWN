using Microsoft.AspNetCore.Mvc;
using ServiceStatus.Controllers;
using ServiceStatus.Models;
using System.Collections.Generic;

namespace ReactCrudDemo.Controllers
{
    public class ServiceController : Controller
    {
        ServiceDataAccess servico = new ServiceDataAccess();

        [HttpGet]
        [Route("Service/Index")]
        public IEnumerable<Servico> Index()
        {
            return servico.GetServico();
        }
    }
}