using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceStatus.Model;
using ServiceStatus.Service;

namespace ServiceStatus.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/failure/v{version:apiVersion}")]
    public class FailureController : ControllerBase
    {
        private readonly ILogger<FailureController> _logger;
        private FailureService _failureService;

        public FailureController(ILogger<FailureController> logger, FailureService failureService)
        {
            _logger = logger;
            _failureService = failureService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var failure = _failureService.FindById(id);

            if (failure == null) return NotFound();
            return Ok(failure);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Failure failure)
        {

            if (failure == null) return BadRequest();
            return Ok(_failureService.Create(failure));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _failureService.Delete(id);
            return NoContent();
        }
    }
}
