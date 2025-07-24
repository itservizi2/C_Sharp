using LessonThirtyFour.Helpers;
using LessonThirtyFour.Models;
using System.Threading.Tasks;

namespace LessonThirtyFour.Services
{
   

    public class BookService : IBookService
    {
        private readonly IBookStore _bookStore;

        public BookService(IBookStore bookStore)
        {
            _bookStore = bookStore;
        }

        public async Task<PagedList<Book>> GetAllBooksAsync(int pageNumber, int pageSize)
        {
            var booksQuery = _bookStore.GetAllBooks();
            return await PagedList<Book>.ToPagedListAsync(booksQuery, pageNumber, pageSize);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookStore.GetByIdAsync(id);
        }

        public async Task<Book> AddAsync(BookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Year = dto.Year,
                CopiesAvailable = dto.CopiesAvailable
            };
            return await _bookStore.AddAsync(book);
        }

        public async Task<bool> UpdateAsync(int id, BookDto dto)
        {
            var bookToUpdate = await _bookStore.GetByIdAsync(id);
            if (bookToUpdate == null) return false;

            bookToUpdate.Title = dto.Title;
            bookToUpdate.Author = dto.Author;
            bookToUpdate.Year = dto.Year;
            bookToUpdate.CopiesAvailable = dto.CopiesAvailable;

            return await _bookStore.UpdateAsync(bookToUpdate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookStore.DeleteAsync(id);
        }
    }
}