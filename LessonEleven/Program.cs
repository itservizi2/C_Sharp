using System;

namespace LessonEleven
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Lesson Eleven Homework");
                Console.WriteLine("Please select a program to execute:");
                Console.WriteLine("1. Parking Lot Simulation");
                Console.WriteLine("2. Database Access Simulation");
                Console.WriteLine("3. Bank Account Transfer");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string? input = Console.ReadLine(); 

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                switch (input)
                {
                    case "1":
                        ParkingLotSimulation.Execute();
                        break;
                    case "2":
                        DatabaseAccessSimulation.Execute();
                        break;
                    case "3":
                        BankAccountTransfer.Execute();
                        break;
                    case "4":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}