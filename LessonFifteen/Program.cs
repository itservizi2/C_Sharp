using System;

namespace LessonFifteen
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Lesson Fifteen Homework");
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 - Employee Information");
            Console.WriteLine("2 - Banking Operations");
            Console.WriteLine("3 - Exit");

            while (true)
            {
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EmployeeInfo.Execute();
                        break;
                    case "2":
                        BankingOperation.Execute();
                        break;
                    case "3":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }

}