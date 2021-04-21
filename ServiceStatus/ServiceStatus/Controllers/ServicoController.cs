using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceStatus.Model;

namespace ServiceStatus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly ILogger<ServicoController> _logger;
        private Service.ServicoService _servicoService; 

        public ServicoController(ILogger<ServicoController> logger, Service.ServicoService servicoService)
        {
            _logger = logger;
            _servicoService = servicoService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_servicoService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var servico = _servicoService.FindById(id);

            if (servico == null) return NotFound();
            return Ok(servico);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Servico servico)
        {

            if (servico == null) return BadRequest();
            return Ok(_servicoService.Create(servico));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Servico servico)
        {

            if (servico == null) return BadRequest();
            return Ok(_servicoService.Update(servico));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _servicoService.Delete(id);
            return NoContent();
        }

    }
}
