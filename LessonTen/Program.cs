using System;

namespace LessonTen
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                
                Console.WriteLine("Lesson Ten Homework");
                Console.WriteLine("1. Compare Files");
                Console.WriteLine("2. Move Files to Backup Folder");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option (1-3): ");

                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    CompareFiles.Execute();
                }
                else if (choice == "2")
                {
                    MoveToFolder.Execute();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Exiting the program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                }
            }
        }
    }
}