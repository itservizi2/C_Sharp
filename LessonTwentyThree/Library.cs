using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int CopiesAvailable { get; set; }
    }

    class LibraryManage
    {
        public static void Execute()
        {
            List<Book> books = new List<Book>
            {
                new Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet", Year = 2019, CopiesAvailable = 5 },
                new Book { Id = 2, Title = "Pro C# 7", Author = "Andrew Troelsen", Year = 2018, CopiesAvailable = 2 },
                new Book { Id = 3, Title = "C# 6.0 and the .NET 4.6 Framework", Author = "Andrew Troelsen", Year = 2015, CopiesAvailable = 0 },
                new Book { Id = 4, Title = "Learning C# by Developing Games", Author = "Harrison Ferrone", Year = 2020, CopiesAvailable = 4 },
                new Book { Id = 5, Title = "CLR via C#", Author = "Jeffrey Richter", Year = 2012, CopiesAvailable = 1 }
            };

            var troelsenBooks = books
                .Where(b => b.Author == "Andrew Troelsen")
                .ToList();

            var sortedByYearDesc = books
                .OrderByDescending(b => b.Year)
                .ToList();

            var availableTitles = books
                .Where(b => b.CopiesAvailable > 0)
                .Select(b => b.Title)
                .ToList();

            var totalCopies = books.Sum(b => b.CopiesAvailable);

            var uniqueAuthors = books
                .Select(b => b.Author)
                .Distinct()
                .ToList();

            var secondPage = books
                .OrderBy(b => b.Title)
                .Skip(2)
                .Take(2)
                .ToList();

            Console.WriteLine("Books by Andrew Troelsen:");
            troelsenBooks.ForEach(b => Console.WriteLine($"- {b.Title}"));

            Console.WriteLine("\nBooks sorted by Year (Descending):");
            sortedByYearDesc.ForEach(b => Console.WriteLine($"- {b.Title} ({b.Year})"));

            Console.WriteLine("\nTitles with available copies:");
            availableTitles.ForEach(title => Console.WriteLine($"- {title}"));

            Console.WriteLine($"\nTotal copies available: {totalCopies}");

            Console.WriteLine("\nUnique Authors:");
            uniqueAuthors.ForEach(author => Console.WriteLine($"- {author}"));

            Console.WriteLine("\nSecond page of results (2 per page, sorted by title):");
            secondPage.ForEach(b => Console.WriteLine($"- {b.Title}"));
        }
    }
}