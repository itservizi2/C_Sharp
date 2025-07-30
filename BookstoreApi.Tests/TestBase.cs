using AutoMapper;
using BookstoreApi.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookstoreApi.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected readonly IMapper _mapper;

        protected TestBase()
        {
            
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        protected BookstoreContext GetBookstoreContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var context = new BookstoreContext(options);
            context.Database.EnsureCreated(); 
            return context;
        }

        public void Dispose()
        {
           
        }
    }
}