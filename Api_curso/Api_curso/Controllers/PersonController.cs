using Api_curso.Model;
using Api_curso.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Api_curso.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService) {
            _logger = logger;
            _personService = personService;
        }
        //metodo responsavel para buscar a lista FindAll()
        [HttpGet]
        public IActionResult Get() {
            return Ok(_personService.FindAll());
        }

        //recebe o parametro id
        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

      
        [HttpPost]
        public IActionResult Post([FromBody] Person person) {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person) {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
             _personService.Delete(id);
            return NoContent();
        }

    }
}
