using AutoMapper;
using BookstoreApi.Data;
using BookstoreApi.Dtos;
using BookstoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization; 


namespace BookstoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return Ok(bookDtos);
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }


        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(CreateBookDto createBookDto)
        {
            
            var authorExists = await _context.Authors.AnyAsync(a => a.Id == createBookDto.AuthorId);
            if (!authorExists)
            {
                
                return BadRequest(new { message = $"Author with ID {createBookDto.AuthorId} does not exist." });
            }

            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == createBookDto.CategoryId);
            if (!categoryExists)
            {
                
                return BadRequest(new { message = $"Category with ID {createBookDto.CategoryId} does not exist." });
            }
            

            var book = _mapper.Map<Book>(createBookDto);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var newBook = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == book.Id);

            var bookDto = _mapper.Map<BookDto>(newBook);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, bookDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, CreateBookDto updateBookDto)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _mapper.Map(updateBookDto, book);

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}