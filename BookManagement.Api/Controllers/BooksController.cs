// Controllers/BooksController.cs
using Microsoft.AspNetCore.Mvc;
using BookManagement.Api.Models;
using BookManagement.Api.Services;

namespace BookManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: /books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }

        // GET: /books/1
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST: /books
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            var addedBook = _bookService.Add(book);
            return CreatedAtAction(nameof(Get), new { id = addedBook.Id }, addedBook);
        }

        // PUT: /books/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            if (id != book.Id)
                return BadRequest();

            if (!_bookService.Update(book))
                return NotFound();

            return NoContent();
        }

        // DELETE: /books/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_bookService.Delete(id))
                return NotFound();

            return NoContent();
        }
    }
}