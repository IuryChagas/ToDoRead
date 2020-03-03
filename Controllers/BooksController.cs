using System;
using Microsoft.AspNetCore.Mvc;
using ToDoRead.Data;
using ToDoRead.Models;

namespace ToDoRead.Controllers
{
    [Route("api/[controller]")]
    [ApiController] public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public BooksController (ApplicationDbContext database)
        {
            this.database = database;
        }
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
        public IActionResult Post([FromBody] Book bookAttribute)
        {
            Book book = new Book();
            book.Title = bookAttribute.Title;
            book.Description = bookAttribute.Description;
            book.Price = bookAttribute.Price;
            book.PageQuantity = bookAttribute.PageQuantity;
            book.Image = bookAttribute.Image;

            book.Publisher = bookAttribute.Publisher;
            book.Language = bookAttribute.Language;

            database.Books.Add(book);
            database.SaveChanges();

            return Ok(new {msg = "Successfully published book."});
        }
    }
}