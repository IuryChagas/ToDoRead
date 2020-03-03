using Microsoft.AspNetCore.Mvc;
using ToDoRead.Models;

namespace ToDoRead.Controllers
{
    [Route("api/[controller]")]
    [ApiController] public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(new {name = "Douglas Iury", company = "GFT"});
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("Iury Chagas " + id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] BookTemp btemp)
        {
            return Ok(new {info = "Novo livro publicado com sucesso.", book = btemp});
        }
        public class BookTemp {
            public string Title { get; set; }
            public float Price { get; set; }
        }
    }
}