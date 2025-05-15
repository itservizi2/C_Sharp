using System;

enum MenuOptionNew
{
    Soup = 1,
    CaesarSalad = 2,
    GreekSalad = 3,
    IceCream = 4
}

class MenuManageNew
{
    public static void Execute()
    {
        Console.WriteLine("Welcome to our restaurant!");
        DisplayMenu();

        while (true)
        {
            Console.Write("Enter the number of your choice: ");
            string input = Console.ReadLine();

            if (input?.ToLower() == "exit")
            {
                Console.WriteLine("Thank you for visiting! Goodbye.");
                break;
            }

            ProcessSelection(input);
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("Please select a menu option:");
        foreach (MenuOptionNew option in Enum.GetValues(typeof(MenuOptionNew)))
        {
            Console.WriteLine($"{(int)option} - {option}");
        }
        Console.WriteLine("Type 'exit' to quit.");
    }

    private static void ProcessSelection(string input)
    {
        if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(MenuOptionNew), choice))
        {
            MenuOptionNew selectedOption = (MenuOptionNew)choice;
            Console.WriteLine(GetMenuDescription(selectedOption));
        }
        else
        {
            Console.WriteLine("Invalid selection. Please enter a number corresponding to the menu options or type 'exit' to quit.");
        }
    }

    private static string GetMenuDescription(MenuOptionNew option) => option switch
    {
        MenuOptionNew.Soup => "Soup - A warm and hearty bowl of goodness. Price: MDL 5.99",
        MenuOptionNew.CaesarSalad => "Caesar Salad - Crisp romaine lettuce with parmesan and croutons. Price: MDL 7.99",
        MenuOptionNew.GreekSalad => "Greek Salad - A refreshing mix of cucumbers, tomatoes, feta cheese, and olives. Price: MDL 8.49",
        MenuOptionNew.IceCream => "Ice Cream - Choose from a variety of delicious flavors. Price: MDL 4.99",
        _ => "Unknown selection."
    };
}