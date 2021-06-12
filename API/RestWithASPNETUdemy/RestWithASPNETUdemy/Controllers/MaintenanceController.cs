
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business.Implementations;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class Maintenanceontroller : ControllerBase
    {
        private readonly ILogger<Maintenanceontroller> _logger;
        private IMaintenanceBusiness _maintenanceBusiness;

        public Maintenanceontroller(ILogger<Maintenanceontroller> logger, IMaintenanceBusiness maintenanceBusiness)
        {
            _logger = logger;
            _maintenanceBusiness = maintenanceBusiness;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_maintenanceBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var service = _maintenanceBusiness.FindById(id);

            if (service == null) return NotFound();
            return Ok(service);
        }

        //Create
        [HttpPost]
        public IActionResult Post([FromBody] Maintenance maintenance)
        {

            if (maintenance == null) return BadRequest();
            return Ok(_maintenanceBusiness.Create(maintenance));
        }

        //Update
        [HttpPut]
        public IActionResult Put([FromBody] Maintenance maintenance)
        {

            if (maintenance == null) return BadRequest();
            return Ok(_maintenanceBusiness.Update(maintenance));
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _maintenanceBusiness.Delete(id);
            return NoContent();
        }

    }
}
