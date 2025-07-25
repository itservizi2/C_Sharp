using LessonThirtyFive.Models;
using System.Linq;
using System.Threading.Tasks;

namespace LessonThirtyFive.Services
{
    public interface IBookStore
    {
        IQueryable<Book> GetAllBooks();
        Task<Book> GetByIdAsync(int id);
        Task<Book> AddAsync(Book book);
        Task<bool> UpdateAsync(Book updated);
        Task<bool> DeleteAsync(int id);
    }
}