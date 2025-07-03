using System;

namespace LessonFive
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Lesson Five Homework");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - BirthDate");
            Console.WriteLine("2 - StudentInfo");
            Console.WriteLine("3 - ValueVsReference");
            Console.WriteLine("4 - BirthDateSecond");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid input. Please enter 1, 2, 3 or 4 :  ");
            }

            switch (choice)
            {
                case 1:
                    BirthDate.Execute();
                    break;
                case 2:
                    StudentInfo.Execute();
                    break;
                case 3:
                    ValueVsReference.Execute();
                    break;
                case 4:
                    BirthDateSecond.Execute();
                    break;
            }
        }
    }
}