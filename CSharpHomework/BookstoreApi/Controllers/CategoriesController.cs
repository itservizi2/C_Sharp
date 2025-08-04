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
    public class CategoriesController : ControllerBase
    {
        private readonly BookstoreContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(BookstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();
            return Ok(_mapper.Map<List<CategoryDto>>(categories));
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, categoryDto);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CreateCategoryDto updateCategoryDto)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCategoryDto, category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            
            var hasBooks = await _context.Books.AnyAsync(b => b.CategoryId == id);
            if (hasBooks)
            {
                return BadRequest("Cannot delete category with associated books.");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}