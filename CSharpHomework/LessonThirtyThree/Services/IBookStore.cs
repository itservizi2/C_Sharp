namespace LessonThirtyThree.Services
{
    using LessonThirtyThree.Models;
    using System.Collections.Generic;

    public interface IBookStore
    {
        IEnumerable<Book> GetAllBooks();
        Book GetById(int id);
        Book Add(Book book);
        bool Update(int id, Book updated);
        bool Delete(int id);
    }
}