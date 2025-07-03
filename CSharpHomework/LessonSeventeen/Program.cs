using System;

namespace LessonSeventeen
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Lesson Seventeen Homework");
                Console.WriteLine("1. Unique Code Generator");
                Console.WriteLine("2. Book Information");
                Console.WriteLine("3. Student Information");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option (1-4): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        UniqueCode.Execute();
                        break;
                    case "2":
                        BookInfo.Execute();
                        break;
                    case "3":
                        StudentInfo.Execute();
                        break;
                    case "4":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}