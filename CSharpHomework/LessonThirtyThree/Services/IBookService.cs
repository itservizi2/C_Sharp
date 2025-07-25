using LessonThirtyThree.Helpers;
using LessonThirtyThree.Models;

namespace LessonThirtyThree.Services
{
    

    public interface IBookService
    {
        PagedList<Book> GetAllBooks(int pageNumber, int pageSize);
        Book GetById(int id);
        Book Add(BookDto dto);
        bool Update(int id, BookDto dto);
        bool Delete(int id);
    }
}