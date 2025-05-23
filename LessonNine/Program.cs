using System;

namespace LessonNine
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Lesson Nine Homework");

                Console.WriteLine("1. Grade Average");
                Console.WriteLine("2. Authentication System");
                Console.WriteLine("3. Inventory Management");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        GradeAverage.Execute();
                        break;
                    case 2:
                        AuthenticationSystem.Execute();
                        break;
                    case 3:
                        InventoryManagement.Execute();
                        break;
                    case 4:
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }

                Console.WriteLine(); 
            }
        }
    }
}