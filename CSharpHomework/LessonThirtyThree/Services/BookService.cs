using LessonThirtyThree.Services;
using LessonThirtyThree.Helpers;
using LessonThirtyThree.Models;

namespace LessonThirtyThree.Services
{
    

    public class BookService : IBookService
    {
        private readonly IBookStore _bookStore;

        public BookService(IBookStore bookStore)
        {
            _bookStore = bookStore;
        }

        public PagedList<Book> GetAllBooks(int pageNumber, int pageSize)
        {
            var books = _bookStore.GetAllBooks();
            return PagedList<Book>.ToPagedList(books, pageNumber, pageSize);
        }

        public Book GetById(int id)
        {
            return _bookStore.GetById(id);
        }

        public Book Add(BookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Year = dto.Year,
                CopiesAvailable = dto.CopiesAvailable
            };
            return _bookStore.Add(book);
        }

        public bool Update(int id, BookDto dto)
        {
            var book = _bookStore.GetById(id);
            if (book == null) return false;

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Year = dto.Year;
            book.CopiesAvailable = dto.CopiesAvailable;

            return _bookStore.Update(id, book);
        }

        public bool Delete(int id)
        {
            return _bookStore.Delete(id);
        }
    }
}