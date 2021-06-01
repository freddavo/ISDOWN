using Microsoft.AspNetCore.Mvc;
using ServiceStatus.Controllers;
using ServiceStatus.Models;
using System.Collections.Generic;

namespace ReactCrudDemo.Controllers
{
    public class DnsController : Controller
    {
        DnsDataAccess dns = new DnsDataAccess();

        [HttpGet]
        [Route("Dns/Index")]
        public IEnumerable<Dns> Index()
        {
            return dns.GetDns();
        }
    }
}