using Microsoft.AspNetCore.Mvc;
using ServiceStatus.Controllers;
using ServiceStatus.Models;
using System.Collections.Generic;

namespace ReactCrudDemo.Controllers
{
    public class AdminController : Controller
    {
        AdminDataAccess admin = new AdminDataAccess();

        [HttpGet]
        [Route("Admin/Index")]
        public IEnumerable<Admin> Index()
        {
            return admin.GetAdmin();
        }
    }
}