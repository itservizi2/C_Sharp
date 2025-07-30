using Xunit;
using AutoMapper;
using BookstoreApi.Controllers;
using BookstoreApi.Data;
using BookstoreApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BookstoreApi.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookstoreApi.Tests
{
    public class BooksControllerTests
    {
        private readonly IMapper _mapper;

        
        public BooksControllerTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>(); 
            });
            _mapper = mapperConfig.CreateMapper();
        }

        private DbContextOptions<BookstoreContext> GetDbOptions(string dbName)
        {
            
            return new DbContextOptionsBuilder<BookstoreContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
        }

        [Fact]
        public async Task GetBooks_ReturnsOkResult_WithAListOfBookDtos()
        {
            
            var dbName = Guid.NewGuid().ToString();
            var options = GetDbOptions(dbName);

            
            await using (var context = new BookstoreContext(options))
            {
                context.Authors.Add(new Author { Name = "Test Author" });
                context.Categories.Add(new Category { Name = "Test Category" });
                await context.SaveChangesAsync();

                context.Books.Add(new Book { Title = "Test Book", AuthorId = 1, CategoryId = 1, Price = 10 });
                await context.SaveChangesAsync();
            }

            
            await using (var context = new BookstoreContext(options))
            {
                var controller = new BooksController(context, _mapper);
                var actionResult = await controller.GetBooks();

                
                var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);

                
                var returnValue = Assert.IsType<List<BookDto>>(okResult.Value);

                
                Assert.Single(returnValue);
                Assert.Equal("Test Book", returnValue[0].Title);
            }
        }
    }
}