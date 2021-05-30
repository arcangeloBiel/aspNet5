using Api_curso.Business;
using Api_curso.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api_curso.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness) {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }
        //metodo responsavel para buscar a lista FindAll()
        [HttpGet]
        public IActionResult Get() {
            return Ok(_bookBusiness.FindAll());
        }

        //recebe o parametro id
        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Book book) {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book) {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            _bookBusiness.Delete(id);
            return NoContent();
        }

    }
}