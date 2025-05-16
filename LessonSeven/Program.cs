namespace LessonSeven;
using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Lesson Seven Homework");

            Console.WriteLine("Select a program to run:");
            Console.WriteLine("1 - Student Grades");
            Console.WriteLine("2 - Employee Info");
            Console.WriteLine("3 - Chess Board");
            Console.WriteLine("4 - Min/Max");
            Console.WriteLine("0 - Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    StudentGrades.Execute();
                    break;
                case 2:
                    EmployeeInfo.Execute();
                    break;
                case 3:
                    ChessBoard.Execute();
                    break;
                case 4:
                    MinMax.Execute();
                    break;
                case 0:
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
