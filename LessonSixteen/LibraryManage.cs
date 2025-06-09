using System;
using System.Collections.Generic;

public interface IBorrowable
{
    void Borrow();
    void Return();
    bool IsBorrowed { get; }
}

public abstract class LibraryItem : IBorrowable
{
    public string Title { get; }
    public string Author { get; }
    public int PublicationYear { get; }
    public bool IsBorrowed { get; private set; }

    protected LibraryItem(string title, string author, int publicationYear)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        IsBorrowed = false;
    }

    public virtual void Borrow()
    {
        if (IsBorrowed)
        {
            Console.WriteLine($"{Title} is already borrowed.");
        }
        else
        {
            IsBorrowed = true;
            Console.WriteLine($"{Title} has been borrowed.");
        }
    }

    public virtual void Return()
    {
        if (!IsBorrowed)
        {
            Console.WriteLine($"{Title} was not borrowed.");
        }
        else
        {
            IsBorrowed = false;
            Console.WriteLine($"{Title} has been returned.");
        }
    }

    public override string ToString()
    {
        return $"{Title} by {Author}, published in {PublicationYear}. {(IsBorrowed ? "Currently borrowed." : "Available.")}";
    }
}

public class Book : LibraryItem
{
    public Book(string title, string author, int publicationYear) : base(title, author, publicationYear) { }
}

public class Magazine : LibraryItem
{
    public Magazine(string title, string author, int publicationYear) : base(title, author, publicationYear) { }
}

public class DVD : LibraryItem
{
    public DVD(string title, string author, int publicationYear) : base(title, author, publicationYear) { }
}

public class Library
{
    private List<LibraryItem> _items = new List<LibraryItem>();

    public void AddItem(LibraryItem item)
    {
        _items.Add(item);
        Console.WriteLine($"{item.Title} added to the library.");
    }

    public void BorrowItem(string title)
    {
        LibraryItem? item = _items.Find(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (item != null)
        {
            item.Borrow();
        }
        else
        {
            Console.WriteLine($"Item '{title}' not found in the library.");
        }
    }

    public void ReturnItem(string title)
    {
        LibraryItem? item = _items.Find(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (item != null)
        {
            item.Return();
        }
        else
        {
            Console.WriteLine($"Item '{title}' not found in the library.");
        }
    }

    public void DisplayItems()
    {
        foreach (var item in _items)
        {
            Console.WriteLine(item);
        }
    }
}

public class LibraryManage
{
    public static void Execute()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\n Library Management System");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Borrow Item");
            Console.WriteLine("3. Return Item");
            Console.WriteLine("4. Display Items");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddLibraryItem(library);
                    break;
                case "2":
                    BorrowLibraryItem(library);
                    break;
                case "3":
                    ReturnLibraryItem(library);
                    break;
                case "4":
                    library.DisplayItems();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine(" Invalid option. Please choose again.");
                    break;
            }
        }
    }

    private static void AddLibraryItem(Library library)
    {
        Console.Write("\nEnter title: ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Enter author: ");
        string author = Console.ReadLine() ?? "";

        Console.Write("Enter publication year: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine(" Invalid year. Operation cancelled.");
            return;
        }

        string type;
        while (true)
        {
            Console.Write("Choose type (Book/Magazine/DVD): ");
            type = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (type == "book" || type == "magazine" || type == "dvd")
            {
                break; 
            }

            Console.WriteLine(" Invalid input! Please choose Book, Magazine, or DVD.");
        }

        LibraryItem item = type switch
        {
            "book" => new Book(title, author, year),
            "magazine" => new Magazine(title, author, year),
            "dvd" => new DVD(title, author, year),
            _ => throw new InvalidOperationException("Unexpected item type") 
        };

        library.AddItem(item);
    }

    private static void BorrowLibraryItem(Library library)
    {
        Console.Write("\nEnter the title of the item to borrow: ");
        string title = Console.ReadLine() ?? "";
        library.BorrowItem(title);
    }

    private static void ReturnLibraryItem(Library library)
    {
        Console.Write("\nEnter the title of the item to return: ");
        string title = Console.ReadLine() ?? "";
        library.ReturnItem(title);
    }
}