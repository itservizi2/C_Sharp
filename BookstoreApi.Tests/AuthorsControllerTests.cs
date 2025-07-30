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
    public class AuthorsControllerTests : TestBase
    {
        [Fact]
        public async Task GetAuthors_ReturnsOkResult_WithListOfAuthors()
        {
            
            var dbName = Guid.NewGuid().ToString();
            await using var context = GetBookstoreContext(dbName);

            context.Authors.Add(new Author { Name = "George Orwell" });
            context.Authors.Add(new Author { Name = "Jane Austen" });
            await context.SaveChangesAsync();

            var controller = new AuthorsController(context, _mapper);

            
            var actionResult = await controller.GetAuthors();

            
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var authors = Assert.IsType<List<AuthorDto>>(okResult.Value);
            Assert.Equal(2, authors.Count);
        }

        [Fact]
        public async Task CreateAuthor_ReturnsCreatedAtActionResult()
        {
            
            var dbName = Guid.NewGuid().ToString();
            await using var context = GetBookstoreContext(dbName);
            var controller = new AuthorsController(context, _mapper);
            var newAuthorDto = new CreateAuthorDto { Name = "New Author" };

            
            var actionResult = await controller.CreateAuthor(newAuthorDto);

            
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var author = Assert.IsType<AuthorDto>(createdAtActionResult.Value);
            Assert.Equal("New Author", author.Name);
        }

        [Fact]
        public async Task DeleteAuthor_ReturnsNoContent_WhenAuthorHasNoBooks()
        {
            
            var dbName = Guid.NewGuid().ToString();
            await using var context = GetBookstoreContext(dbName);
            var authorToDelete = new Author { Name = "Author To Delete" };
            context.Authors.Add(authorToDelete);
            await context.SaveChangesAsync();

            var controller = new AuthorsController(context, _mapper);

            
            var result = await controller.DeleteAuthor(authorToDelete.Id);

            
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAuthor_ReturnsBadRequest_WhenAuthorHasBooks()
        {
            
            var dbName = Guid.NewGuid().ToString();
            await using var context = GetBookstoreContext(dbName);

            var author = new Author { Name = "Author With Book" };
            var category = new Category { Name = "Fiction" };
            context.AddRange(author, category);
            await context.SaveChangesAsync();

            var book = new Book { Title = "A Book", AuthorId = author.Id, CategoryId = category.Id, Price = 20 };
            context.Books.Add(book);
            await context.SaveChangesAsync();

            var controller = new AuthorsController(context, _mapper);

            
            var result = await controller.DeleteAuthor(author.Id);

            
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Cannot delete author with associated books.", badRequestResult.Value);
        }
    }
}