
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business.Implementations;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
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
        public IActionResult Get(long id)
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
        public IActionResult Put([FromBody] Time time)
        {

            if (time == null) return BadRequest();
            return Ok(_timeBusiness.Update(time));
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _timeBusiness.Delete(id);
            return NoContent();
        }

    }
}
