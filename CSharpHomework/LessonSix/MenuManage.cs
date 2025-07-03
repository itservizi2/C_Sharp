using System;

enum MenuOption
{
    Soup = 1,
    CaesarSalad = 2,
    GreekSalad = 3,
    IceCream = 4
}

class MenuManage
{
    public static void Execute()
    {
        Console.WriteLine("Welcome to our restaurant!");
        Console.WriteLine("Please select a menu option:");
        Console.WriteLine("1 - Soup");
        Console.WriteLine("2 - Caesar Salad");
        Console.WriteLine("3 - Greek Salad");
        Console.WriteLine("4 - Ice Cream");
        Console.WriteLine("Type 'exit' to quit.");

        while (true)
        {
            Console.Write("Enter the number of your choice: ");
            string input = Console.ReadLine();

            if (input?.ToLower() == "exit")
            {
                Console.WriteLine("Thank you for visiting! Goodbye.");
                break;
            }

            if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(MenuOption), choice))
            {
                MenuOption selectedOption = (MenuOption)choice;
                switch (selectedOption)
                {
                    case MenuOption.Soup:
                        Console.WriteLine("Soup - A warm and hearty bowl of goodness. Price: MDL 5.99");
                        break;
                    case MenuOption.CaesarSalad:
                        Console.WriteLine("Caesar Salad - Crisp romaine lettuce with parmesan and croutons. Price: MDL 7.99");
                        break;
                    case MenuOption.GreekSalad:
                        Console.WriteLine("Greek Salad - A refreshing mix of cucumbers, tomatoes, feta cheese, and olives. Price: MDL 8.49");
                        break;
                    case MenuOption.IceCream:
                        Console.WriteLine("Ice Cream - Choose from a variety of delicious flavors. Price: MDL 4.99");
                        break;
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter a number between 1 and 4 or type 'exit' to quit.");
            }
        }
    }
}