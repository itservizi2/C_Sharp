using System.Linq;
using System.Threading.Tasks;
using LessonThirtyFive.Data;
using LessonThirtyFive.Models;
using Microsoft.EntityFrameworkCore;

namespace LessonThirtyFive.Services
{
   

    public class BookStore : IBookStore
    {
        private readonly ApplicationDbContext _context;

        public BookStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> GetAllBooks()
        {
            return _context.Books.AsQueryable();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> UpdateAsync(Book updated)
        {
            _context.Entry(updated).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Books.AnyAsync(e => e.Id == updated.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}