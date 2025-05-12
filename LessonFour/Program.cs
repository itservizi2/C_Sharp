using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nLesson Four Homework - Choose an Option:");
            Console.WriteLine("1. Temperature Conversion");
            Console.WriteLine("2. Body Mass Index Calculation");
            Console.WriteLine("3. Employee Salary Calculation");
            Console.WriteLine("4. Simple Calculator");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    TemperatureConversion.Execute();
                    break;
                case 2:
                    BodyMassIndex.Execute();
                    break;
                case 3:
                    EmployeeSalary.Execute();
                    break;
                case 4:
                    SimpleCalculator.Execute();
                    break;
                case 5:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}
