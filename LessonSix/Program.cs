using System;

namespace LessonSix
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Lesson Six Homework - Choose a program to run:");

                Console.WriteLine("1. FilterAndProcess");
                Console.WriteLine("2. StudentGrade");
                Console.WriteLine("3. MenuManage");
                Console.WriteLine("4. TriangleClassifier");
                Console.WriteLine("5. ArithmeticCalculator");
                Console.WriteLine("6. SeasonCheck");
                Console.WriteLine("7. IdentifyType");
                Console.WriteLine("8. IdentifyTypeLambda");
                Console.WriteLine("9. ShapeArea");
                Console.WriteLine("10. EmployeeSalary");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                if (choice == 0)
                {
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                }

                switch (choice)
                {
                    case 1: FilterAndProcess.Execute(); break;
                    case 2: StudentGrade.Execute(); break;
                    case 3: MenuManage.Execute(); break;
                    case 4: TriangleClassifier.Execute(); break;
                    case 5: ArithmeticCalculator.Execute(); break;
                    case 6: SeasonCheck.Execute(); break;
                    case 7: IdentifyType.Execute(); break;
                    case 8: IdentifyTypeLambda.Execute(); break;
                    case 9: ShapeArea.Execute(); break;
                    case 10: EmployeeSalary.Execute(); break;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a valid number from the menu.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}