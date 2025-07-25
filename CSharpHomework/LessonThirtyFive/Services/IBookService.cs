using LessonThirtyFive.Helpers;
using LessonThirtyFive.Models;
using System.Threading.Tasks;

namespace LessonThirtyFive.Services
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