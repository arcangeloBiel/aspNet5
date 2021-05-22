using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Api_curso.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase {
       

        public PersonController(ILogger<PersonController> logger) {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber) {
            return BadRequest("Invalid Input");
        }

      
       

    }
}
