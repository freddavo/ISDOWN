
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business.Implementations;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ServicoController : ControllerBase
    {
        private readonly ILogger<ServicoController> _logger;
        private IServicoBusiness _servicoBusiness;

        public ServicoController(ILogger<ServicoController> logger, IServicoBusiness servicoBusiness)
        {
            _logger = logger;
            _servicoBusiness = servicoBusiness;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_servicoBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var service = _servicoBusiness.FindById(id);

            if (service == null) return NotFound();
            return Ok(service);
        }

        //Create
        [HttpPost]
        public IActionResult Post([FromBody] Servico servico)
        {

            if (servico == null) return BadRequest();
            return Ok(_servicoBusiness.Create(servico));
        }

        //Update
        [HttpPut]
        public IActionResult Put([FromBody] Servico servico)
        {

            if (servico == null) return BadRequest();
            return Ok(_servicoBusiness.Update(servico));
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _servicoBusiness.Delete(id);
            return NoContent();
        }

    }
}
