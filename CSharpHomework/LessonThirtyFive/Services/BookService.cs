using LessonThirtyFive.Helpers;
using LessonThirtyFive.Models;
using LessonThirtyFive.Repositories; 
using System.Threading.Tasks;

namespace LessonThirtyFive.Services
{
    public class BookService : IBookService
    {
        
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<PagedList<Book>> GetAllBooksAsync(int pageNumber, int pageSize)
        {
            
            var booksQuery = _bookRepository.GetAll();
            return await PagedList<Book>.ToPagedListAsync(booksQuery, pageNumber, pageSize);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
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
            return await _bookRepository.AddAsync(book);
        }

        public async Task<bool> UpdateAsync(int id, BookDto dto)
        {
            var bookToUpdate = await _bookRepository.GetByIdAsync(id);
            if (bookToUpdate == null) return false;

            bookToUpdate.Title = dto.Title;
            bookToUpdate.Author = dto.Author;
            bookToUpdate.Year = dto.Year;
            bookToUpdate.CopiesAvailable = dto.CopiesAvailable;

            return await _bookRepository.UpdateAsync(bookToUpdate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookRepository.DeleteAsync(id);
        }
    }
}
