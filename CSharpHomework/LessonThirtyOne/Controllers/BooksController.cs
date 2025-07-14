namespace LessonThirtyOne.Controllers
{
    using LessonThirtyOne.Models;
    using LessonThirtyOne.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookStore _bookStore;

        public BooksController(BookStore bookStore)
        {
            _bookStore = bookStore;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _bookStore.GetAllBooks();
            if (books == null || !books.Any())
                return NoContent();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _bookStore.GetById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Year = dto.Year,
                CopiesAvailable = dto.CopiesAvailable
            };

            var added = _bookStore.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = added.Id }, added);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedBook = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Year = dto.Year,
                CopiesAvailable = dto.CopiesAvailable
            };

            bool success = _bookStore.Update(id, updatedBook);
            if (!success)
                return NotFound();

            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool success = _bookStore.Delete(id);
            if (!success)
                return NotFound();

            return NoContent();
        }


    }
}