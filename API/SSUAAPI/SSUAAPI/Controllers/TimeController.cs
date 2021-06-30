using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSUAAPI.Business;
using SSUAAPI.Model;

namespace SSUAAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        private readonly ILogger<TimeController> _logger;
        private ITimeBusiness _timeBusiness;

        public TimeController(ILogger<TimeController> logger, ITimeBusiness timeBusiness)
        {
            _logger = logger;
            _timeBusiness = timeBusiness;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_timeBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var service = _timeBusiness.FindById(id);

            if (service == null) return NotFound();
            return Ok(service);
        }

        //Create
        [HttpPost]
        public IActionResult Post([FromBody] Time time)
        {

            if (time == null) return BadRequest();
            return Ok(_timeBusiness.Create(time));
        }

        //Update
        [HttpPut]
        public IActionResult Put([FromBody] Time service)
        {

            if (service == null) return BadRequest();
            return Ok(_timeBusiness.Update(service));
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _timeBusiness.Delete(id);
            return NoContent();
        }

    }
}
