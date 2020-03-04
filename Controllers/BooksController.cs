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
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
                //return BadRequest(new {msg = "invalid Id"});
            }

        }
        [HttpPost]
        public IActionResult Post([FromBody] Book bookAttribute)
        {
            // *validation
            if (bookAttribute.Price <= 0)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new {msg = "Price cannot be less than or equal to 0!"});
            }
            if (
                string.IsNullOrWhiteSpace(bookAttribute.Title)  ||
                string.IsNullOrWhiteSpace(bookAttribute.Description) ||
                string.IsNullOrWhiteSpace(bookAttribute.PageQuantity.ToString()) ||
                string.IsNullOrWhiteSpace(bookAttribute.Image) ||
                string.IsNullOrWhiteSpace(bookAttribute.Publisher) ||
                string.IsNullOrWhiteSpace(bookAttribute.Language)
                )
            {
                Response.StatusCode = 400;
                return new ObjectResult(new {msg = "The attribute Must have more than one characters!"});
            }
            Book book = new Book();

            book.Title = bookAttribute.Title;
            book.Description = bookAttribute.Description;
            book.Price = bookAttribute.Price;
            book.PageQuantity = bookAttribute.PageQuantity;
            book.Image = bookAttribute.Image;
            book.Publisher = bookAttribute.Publisher;

            if (!ModelState.IsValid){ }
            book.Language = bookAttribute.Language;

            database.Books.Add(book);
            database.SaveChanges();

            Response.StatusCode =  201;
            return new ObjectResult("");
            //return Ok(new {msg = "Successfully published book."});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Book book = database.Books.First(book => book.Id == id);
                database.Books.Remove(book);
                database.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }
    }
}