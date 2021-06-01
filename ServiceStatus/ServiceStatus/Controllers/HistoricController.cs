using Microsoft.AspNetCore.Mvc;
using ServiceStatus.Controllers;
using ServiceStatus.Models;
using System.Collections.Generic;

namespace ReactCrudDemo.Controllers
{
    public class HistoricController : Controller
    {
        HistoricDataAccess historico = new HistoricDataAccess();

        [HttpGet]
        [Route("Historic/Index")]
        public IEnumerable<Historico> Index()
        {
            return historico.GetHistoric();
        }
    } 
}