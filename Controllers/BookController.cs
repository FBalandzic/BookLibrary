using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BookWebApp.Repository;
using BookWebApp.Model;
using Microsoft.AspNetCore.Cors;

namespace BookWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookRep bookRep = new BookRep();

        [HttpGet]
        public ActionResult<IEnumerable<Book>> getAllBooks()
        {
            var books = bookRep.getAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult getBookById(string id)
        {
            Book book = bookRep.getBookById(id);
            return Ok(book);
        }

        [HttpPost]
        public ActionResult addBook([FromBody] Book book)
        {
            Console.WriteLine("TEST");
            Console.WriteLine(book);
            bookRep.addBook(book);
            return Ok();
        }

        [HttpPost("updateBook")]
        public ActionResult updateBook([FromBody] Book book)
        {
            Console.WriteLine("TEST");
            Console.WriteLine(book);
            bookRep.updateBook(book);
            return Ok(book);
        }

        [HttpPost("deleteBook")]
        public ActionResult deleteBook([FromBody] BookUpdateModel book)
        {
            bookRep.deleteBook(book);
            return Ok(book);
        }
    }
}
