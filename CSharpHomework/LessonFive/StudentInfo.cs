using System;

namespace LessonFive
{
    enum StudyYear { I = 1, II, III, IV, V, VI }

    struct Student
    {
        public string Name;
        public int Age;
        public string FieldOfStudy;
        public StudyYear Year;

        public void DisplayInfo()
        {
            Console.WriteLine("\nStudent Information:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"FieldOfStudy: {FieldOfStudy}");
            Console.WriteLine($"Year of Study: {Year}");
        }
    }

    class StudentInfo
    {
        public static void Execute()
        {
            Student student;

            Console.Write("Enter student name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter student age: ");
            while (!int.TryParse(Console.ReadLine(), out student.Age) || student.Age <= 0)
                Console.Write("Invalid input. Please enter a valid age: ");

            Console.Write("Enter student field of study: ");
            student.FieldOfStudy = Console.ReadLine();

            Console.Write("Enter year of study (I, II, III, IV, V, VI): ");
            while (!Enum.TryParse(Console.ReadLine(), out student.Year) || !Enum.IsDefined(typeof(StudyYear), student.Year))
                Console.Write("Invalid input. Please enter a valid year (I, II, III, IV, V, VI): ");

            student.DisplayInfo();
        }
    }
}
