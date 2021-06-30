using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSUAAPI.Business;
using SSUAAPI.Model;

namespace SSUAAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;
        private IServiceBusiness _serviceBusiness;

        public ServiceController(ILogger<ServiceController> logger, IServiceBusiness serviceBusiness)
        {
            _logger = logger;
            _serviceBusiness = serviceBusiness;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var service = _serviceBusiness.FindById(id);

            if (service == null) return NotFound();
            return Ok(service);
        }

        //Create
        [HttpPost]
        public IActionResult Post([FromBody] Service service)
        {

            if (service == null) return BadRequest();
            return Ok(_serviceBusiness.Create(service));
        }

        //Update
        [HttpPut]
        public IActionResult Put([FromBody] Service service)
        {

            if (service == null) return BadRequest();
            return Ok(_serviceBusiness.Update(service));
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _serviceBusiness.Delete(id);
            return NoContent();
        }

    }
}
