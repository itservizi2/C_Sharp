using System;

class Book
{
    
    public string Title { get; }
    public string Author { get; }
    public int YearPublished { get; }
    public int NumberPages { get; }

    public Book(string title, string author, int yearPublished, int numberPages)
    {
        Title = title;
        Author = author;
        YearPublished = yearPublished;
        NumberPages = numberPages;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Year Published: {YearPublished}");
        Console.WriteLine($"Number of Pages: {NumberPages}");
    }
}

class BookInfo
{
    public static void Execute()
    {
       
        Book myBook = new Book("Amintiri din copilarie", "Ion Creanga", 2021, 120);

        myBook.ShowDetails();
    }
}