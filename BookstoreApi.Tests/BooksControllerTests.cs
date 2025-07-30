using Xunit;
using BookstoreApi.Controllers;
using BookstoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using BookstoreApi.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookstoreApi.Tests
{
    public class BooksControllerTests : TestBase 
    {
        [Fact]
        public async Task GetBooks_ReturnsOkResult_WithListOfBookDtos()
        {
            
            var dbName = Guid.NewGuid().ToString();
            await using var context = GetBookstoreContext(dbName); 

            var author = new Author { Name = "Test Author" };
            var category = new Category { Name = "Test Category" };
            context.Authors.Add(author);
            context.Categories.Add(category);
            await context.SaveChangesAsync();

            context.Books.Add(new Book { Title = "Test Book", AuthorId = author.Id, CategoryId = category.Id, Price = 10 });
            await context.SaveChangesAsync();

            var controller = new BooksController(context, _mapper);

            
            var actionResult = await controller.GetBooks();

            
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var books = Assert.IsType<List<BookDto>>(okResult.Value);
            Assert.Single(books);
            Assert.Equal("Test Book", books[0].Title);
        }

        
    }
}