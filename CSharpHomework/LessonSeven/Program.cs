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
            Console.WriteLine("5 - SumAverage");
            Console.WriteLine("6 - Reverse");
            Console.WriteLine("7 - Duplicates Remove");
            Console.WriteLine("8 - Push Pop Peek");
            Console.WriteLine("9 - QueueOperations");
            Console.WriteLine("0 - Exit");
            Console.Write("Enter your choice: ");

            string? input = Console.ReadLine();  
            if (string.IsNullOrWhiteSpace(input))  
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

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
                case 5:
                    SumAverage.Execute();
                    break;
                case 6:
                    Reverse.Execute();
                    break;
                case 7:
                    DuplicatesRemove.Execute();
                    break;
                case 8:
                    PushPopPeek.Execute();
                    break;
                case 9:
                    QueueOperations.Execute();
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