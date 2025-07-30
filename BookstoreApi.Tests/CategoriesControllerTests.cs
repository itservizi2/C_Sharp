using Xunit;
using BookstoreApi.Controllers;
using BookstoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using BookstoreApi.Dtos;
using System;
using System.Threading.Tasks;

namespace BookstoreApi.Tests
{
    public class CategoriesControllerTests : TestBase
    {
        [Fact]
        public async Task CreateCategory_ReturnsCreatedAtActionResult()
        {
           
            var dbName = Guid.NewGuid().ToString();
            await using var context = GetBookstoreContext(dbName);
            var controller = new CategoriesController(context, _mapper);
            var newCategoryDto = new CreateCategoryDto { Name = "Science Fiction" };

            
            var actionResult = await controller.CreateCategory(newCategoryDto);

            
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var category = Assert.IsType<CategoryDto>(createdAtActionResult.Value);
            Assert.Equal("Science Fiction", category.Name);
        }

        [Fact]
        public async Task DeleteCategory_ReturnsBadRequest_WhenCategoryHasBooks()
        {
            
            var dbName = Guid.NewGuid().ToString();
            await using var context = GetBookstoreContext(dbName);

            var author = new Author { Name = "Some Author" };
            var category = new Category { Name = "Category With Book" };
            context.AddRange(author, category);
            await context.SaveChangesAsync();

            var book = new Book { Title = "A Book", AuthorId = author.Id, CategoryId = category.Id, Price = 20 };
            context.Books.Add(book);
            await context.SaveChangesAsync();

            var controller = new CategoriesController(context, _mapper);

            
            var result = await controller.DeleteCategory(category.Id);

            
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Cannot delete category with associated books.", badRequestResult.Value);
        }
    }
}