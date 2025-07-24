using LessonThirtyThree.Services;
using System.Collections.Generic;
using System.Linq;
using LessonThirtyThree.Models;

namespace LessonThirtyThree.Services
{
    

    public class BookStore : IBookStore
    {
        private readonly List<Book> _books;

        public BookStore()
        {
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet", Year = 2019, CopiesAvailable = 5 },
                new Book { Id = 2, Title = "Pro C# 7", Author = "Andrew Troelsen", Year = 2018, CopiesAvailable = 2 },
                new Book { Id = 3, Title = "C# 6.0 and the .NET 4.6 Framework", Author = "Andrew Troelsen", Year = 2015, CopiesAvailable = 0 },
                new Book { Id = 4, Title = "Learning C# by Developing Games", Author = "Harrison Ferrone", Year = 2020, CopiesAvailable = 4 },
                new Book { Id = 5, Title = "CLR via C#", Author = "Jeffrey Richter", Year = 2012, CopiesAvailable = 1 }
            };
        }

        public IEnumerable<Book> GetAllBooks() => _books;

        public Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public Book Add(Book book)
        {
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
            return book;
        }

        public bool Update(int id, Book updated)
        {
            var book = GetById(id);
            if (book == null) return false;

            book.Title = updated.Title;
            book.Author = updated.Author;
            book.Year = updated.Year;
            book.CopiesAvailable = updated.CopiesAvailable;
            return true;
        }

        public bool Delete(int id)
        {
            var book = GetById(id);
            if (book == null) return false;
            return _books.Remove(book);
        }
    }
}