using LessonThirtyFour.Helpers;
using LessonThirtyFour.Models;
using System.Threading.Tasks;

namespace LessonThirtyFour.Services
{
   

    public interface IBookService
    {
        Task<PagedList<Book>> GetAllBooksAsync(int pageNumber, int pageSize);
        Task<Book> GetByIdAsync(int id);
        Task<Book> AddAsync(BookDto dto);
        Task<bool> UpdateAsync(int id, BookDto dto);
        Task<bool> DeleteAsync(int id);
    }
}