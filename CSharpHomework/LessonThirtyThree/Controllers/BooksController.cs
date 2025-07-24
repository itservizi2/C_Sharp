using LessonThirtyThree.Helpers;
using LessonThirtyThree.Models;
using LessonThirtyThree.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace LessonThirtyThree.Controllers
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
        public ActionResult<IEnumerable<Book>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var pagedBooks = _bookService.GetAllBooks(pageNumber, pageSize);

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
        public ActionResult<Book> GetById(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var added = _bookService.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = added.Id, version = "1.0" }, added);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _bookService.Update(id, dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _bookService.Delete(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}