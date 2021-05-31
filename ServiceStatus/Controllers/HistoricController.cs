using Microsoft.AspNetCore.Mvc;
using ServiceStatus.Controllers;
using ServiceStatus.Models;
using System.Collections.Generic;

namespace ReactCrudDemo.Controllers
{
    public class HistoricController : Controller
    {
        HistoricDataAccess historic = new HistoricDataAccess();

        /*[HttpGet]
        [Route("Historic/Index")]
        public IEnumerable<Historico> Index()
        {
            return historic.GetHistoric();
        }*/
    } 
}