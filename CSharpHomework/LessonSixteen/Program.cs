using System;

namespace LessonSixteen
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Lesson Sixteen Homework");
                Console.WriteLine("1. Employee Management");
                Console.WriteLine("2. Library Management");
                Console.WriteLine("3. Math Calculator");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        EmployeeManage.Execute();
                        break;
                    case "2":
                        LibraryManage.Execute();
                        break;
                    case "3":
                        MathCalculator.Execute();
                        break;
                    case "0":
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
