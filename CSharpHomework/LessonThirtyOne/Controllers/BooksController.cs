namespace LessonThirtyOne.Controllers
{
    using LessonThirtyOne.Models;
    using LessonThirtyOne.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll() => Ok(BookStore.Books);

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = BookStore.Books.FirstOrDefault(b => b.Id == id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newId = BookStore.Books.Max(b => b.Id) + 1;
            var book = new Book
            {
                Id = newId,
                Title = dto.Title,
                Author = dto.Author,
                Year = dto.Year,
                CopiesAvailable = dto.CopiesAvailable
            };
            BookStore.Books.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BookDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var book = BookStore.Books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Year = dto.Year;
            book.CopiesAvailable = dto.CopiesAvailable;

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = BookStore.Books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();

            BookStore.Books.Remove(book);
            return NoContent();
        }
    }
}
