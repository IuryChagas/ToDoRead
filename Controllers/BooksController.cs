using System;
using Microsoft.AspNetCore.Mvc;
using ToDoRead.Data;
using ToDoRead.Models;
using System.Linq;

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
            var books = database.Books.ToList();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Book book = database.Books.First(book => book.Id == id);
                return Ok(book);
            }
            catch (Exception n)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
                //return BadRequest(new {msg = "invalid Id"});
            }

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

            Response.StatusCode =  201;
            return new ObjectResult("");
            //return Ok(new {msg = "Successfully published book."});
        }
    }
}