using AutoMapper;
using BookstoreApi.Data;
using BookstoreApi.Dtos;
using BookstoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookstoreContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(BookstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _context.Authors.AsNoTracking().ToListAsync();
            return Ok(_mapper.Map<List<AuthorDto>>(authors));
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _context.Authors.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AuthorDto>(author));
        }

       
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = _mapper.Map<Author>(createAuthorDto);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            var authorDto = _mapper.Map<AuthorDto>(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, authorDto);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, CreateAuthorDto updateAuthorDto)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            _mapper.Map(updateAuthorDto, author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            
            var hasBooks = await _context.Books.AnyAsync(b => b.AuthorId == id);
            if (hasBooks)
            {
                return BadRequest("Cannot delete author with associated books.");
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}