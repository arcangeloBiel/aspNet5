using Api_curso.Business;
using Api_curso.Data.VO;
using Api_curso.HiperMidia.Filters;
using Api_curso.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Api_curso.Controllers {
   // [ApiVersion("1")]
   // [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness) {
            _logger = logger;
            _personBusiness = personBusiness;
        }
        //metodo responsavel para buscar a lista FindAll()
        [HttpGet]
        [TypeFilter(typeof(HiperMediaFilter))]
        public IActionResult Get() {
            return Ok(_personBusiness.FindAll());
        }

        //recebe o parametro id
        [HttpGet("{id}")]
        [TypeFilter(typeof(HiperMediaFilter))]
        public IActionResult Get(long id) {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

      
        [HttpPost]
        [TypeFilter(typeof(HiperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person) {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        [TypeFilter(typeof(HiperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person) {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HiperMediaFilter))]
        public IActionResult Delete(long id) {
            _personBusiness.Delete(id);
            return NoContent();
        }

    }
}
