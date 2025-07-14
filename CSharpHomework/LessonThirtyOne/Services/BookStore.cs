namespace LessonThirtyOne.Services
{
    using System.Collections.Generic;
    using LessonThirtyOne.Models;

    public static class BookStore
    {
        public static List<Book> Books = new List<Book> {
        new Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet", Year = 2019, CopiesAvailable = 5 },
        new Book { Id = 2, Title = "Pro C# 7", Author = "Andrew Troelsen", Year = 2018, CopiesAvailable = 2 },
        new Book { Id = 3, Title = "C# 6.0 and the .NET 4.6 Framework", Author = "Andrew Troelsen", Year = 2015, CopiesAvailable = 0 },
        new Book { Id = 4, Title = "Learning C# by Developing Games", Author = "Harrison Ferrone", Year = 2020, CopiesAvailable = 4 },
        new Book { Id = 5, Title = "CLR via C#", Author = "Jeffrey Richter", Year = 2012, CopiesAvailable = 1 }
    };
    }
}
