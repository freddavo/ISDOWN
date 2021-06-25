
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business.Implementations;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
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
        public IActionResult Get(long id)
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
        public IActionResult Delete(long id)
        {
            _serviceBusiness.Delete(id);
            return NoContent();
        }

    }
}
