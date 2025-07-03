using System;

namespace LessonEight
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nLesson Eight Homework - Choose an option:");

                Console.WriteLine("1. Display even numbers from 1 to 100");
                Console.WriteLine("2. Enter numbers until 0 is entered");
                Console.WriteLine("3. Manage people information");
                Console.WriteLine("4. Display only even numbers (custom range)");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 5.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        DisplayOnlyEven.Execute();
                        break;
                    case 2:
                        UntilZero.Execute();
                        break;
                    case 3:
                        PersonInfo.Execute();
                        break;
                    case 4:
                        EvenNumbers.Execute();
                        break;
                    case 5:
                        Console.WriteLine("Exiting program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}