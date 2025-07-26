using LessonThirtyFive.Data;
using LessonThirtyFive.Models;
using LessonThirtyFive.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LessonThirtyFive.Tests.Repositories
{
    public class BookRepositoryTests
    {
   
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString()) 
                .Options;
            var context = new ApplicationDbContext(options);
            SeedData(context);
            return context;
        }

   
        private void SeedData(ApplicationDbContext context)
        {
            context.Books.AddRange(
                new Book { Id = 1, Title = "Pro C# 10 with .NET 6", Author = "Pro C# 10 with .NET 6", Year = 2022, CopiesAvailable = 1 },
                new Book { Id = 2, Title = "Learn C# In One Day", Author = "Jamie Chan", Year = 2015, CopiesAvailable = 2 }
            );
            context.SaveChanges();
        }

        [Fact]
        public async Task GetAll_ReturnsAllBooks()
        {
            
            await using var context = GetInMemoryDbContext();
            var repository = new BookRepository(context);

           
            var books = repository.GetAll();

            
            Assert.NotNull(books);
            Assert.Equal(2, await books.CountAsync());
        }

        [Fact]
        public async Task GetByIdAsync_WithValidId_ReturnsCorrectBook()
        {
            
            await using var context = GetInMemoryDbContext();
            var repository = new BookRepository(context);
            var testId = 1;

            
            var book = await repository.GetByIdAsync(testId);

            
            Assert.NotNull(book);
            Assert.Equal(testId, book.Id);
            Assert.Equal("Pro C# 10 with .NET 6", book.Title);
        }

        [Fact]
        public async Task GetByIdAsync_WithInvalidId_ReturnsNull()
        {
            
            await using var context = GetInMemoryDbContext();
            var repository = new BookRepository(context);
            var testId = 999;

            
            var book = await repository.GetByIdAsync(testId);

            
            Assert.Null(book);
        }

        [Fact]
        public async Task AddAsync_AddsBookToDatabase()
        {
            
            await using var context = GetInMemoryDbContext();
            var repository = new BookRepository(context);
            var newBook = new Book { Title = "Unit Testing Principles, Practices, and Patterns", Author = "Vladimir Khorikov", Year = 2020, CopiesAvailable = 5 };

            
            var addedBook = await repository.AddAsync(newBook);
            var allBooks = await context.Books.ToListAsync();

            
            Assert.NotNull(addedBook);
            Assert.Equal(3, allBooks.Count); 
            Assert.Contains(allBooks, b => b.Title == "Unit Testing Principles, Practices, and Patterns");
        }

        [Fact]
        public async Task UpdateAsync_UpdatesExistingBook()
        {
            
            await using var context = GetInMemoryDbContext();
            var repository = new BookRepository(context);
            var bookToUpdate = await context.Books.FindAsync(1);
            bookToUpdate.Title = "Updated Title";

            
            var result = await repository.UpdateAsync(bookToUpdate);
            var updatedBook = await context.Books.FindAsync(1);

            
            Assert.True(result);
            Assert.NotNull(updatedBook);
            Assert.Equal("Updated Title", updatedBook.Title);
        }

        [Fact]
        public async Task DeleteAsync_WithValidId_RemovesBookFromDatabase()
        {
            
            await using var context = GetInMemoryDbContext();
            var repository = new BookRepository(context);
            var testId = 1;

            
            var result = await repository.DeleteAsync(testId);
            var book = await context.Books.FindAsync(testId);
            var bookCount = await context.Books.CountAsync();

            
            Assert.True(result);
            Assert.Null(book);
            Assert.Equal(1, bookCount); 
        }

        [Fact]
        public async Task DeleteAsync_WithInvalidId_ReturnsFalse()
        {
            
            await using var context = GetInMemoryDbContext();
            var repository = new BookRepository(context);
            var testId = 999;

            
            var result = await repository.DeleteAsync(testId);
            var bookCount = await context.Books.CountAsync();

            
            Assert.False(result);
            Assert.Equal(2, bookCount); 
        }
    }
}

