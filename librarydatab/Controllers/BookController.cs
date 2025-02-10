using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFull.Models;
using RestFull.Repositories.Interfaces;

namespace RestFull.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface bookInterface;

        public BookController(IBookInterface bookInterface)
        {
            this.bookInterface = bookInterface;
        }

        [HttpGet("feladat10")]
        public async Task<ActionResult> GetAllBooks()
        {
            var books = await bookInterface.GetAllBooks();

            if (books != null)
            {
                return Ok(books);
            }
            return BadRequest();
        }

        [HttpPost("feladat13")]
        public async Task<ActionResult<string>> AddNewBook(string id, Book book)
        {
            var result = await bookInterface.AddNewBook(id, book);
            if (result.Contains("sikeres"))
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("feladat15")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await bookInterface.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpPut("feladat16")]
        public async Task<ActionResult<Book>> Put(int id, Book book)
        {
            var result = await bookInterface.Put(id, book);
            if (result != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        [HttpDelete("feladat17")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var result = await bookInterface.Delete(id);
            if (result.Contains("sikeres"))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
