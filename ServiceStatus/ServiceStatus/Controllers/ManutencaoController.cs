using Microsoft.AspNetCore.Mvc;
using ServiceStatus.Controllers;
using ServiceStatus.Models;
using System.Collections.Generic;

namespace ReactCrudDemo.Controllers
{
    public class ManutencaoController : Controller
    {
        ManutencaoDataAccess manutencao = new ManutencaoDataAccess();

        [HttpGet]
        [Route("Manutencao/Index")]
        public IEnumerable<Manutencao> Index()
        {
            return manutencao.GetManutencao();
        }
    }
}