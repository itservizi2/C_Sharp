using LessonThirtyFive.Models;
using LessonThirtyFive.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LessonThirtyFive.Controllers
{
  

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var pagedBooks = await _bookService.GetAllBooksAsync(pageNumber, pageSize);

            var metadata = new
            {
                pagedBooks.TotalCount,
                pagedBooks.PageSize,
                pagedBooks.CurrentPage,
                pagedBooks.TotalPages,
                pagedBooks.HasNext,
                pagedBooks.HasPrevious
            };

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metadata));

            if (pagedBooks == null || !pagedBooks.Any())
                return NoContent();

            return Ok(pagedBooks);
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "id" })]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var added = await _bookService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = added.Id, version = "1.0" }, added);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _bookService.UpdateAsync(id, dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _bookService.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}