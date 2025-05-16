using System;

class StudentGrades
{
    public static void Execute()
    {
        
        Console.Write("Enter the number of students: ");
        int numStudents;

        while (!int.TryParse(Console.ReadLine(), out numStudents) || numStudents <= 0)
        {
            Console.Write("Invalid input. Please enter a positive integer: ");
        }

        string[] studentNames = new string[numStudents];
        int[] grades = new int[numStudents];

        for (int i = 0; i < numStudents; i++)
        {
            Console.Write($"Enter name for student {i + 1}: ");
            studentNames[i] = Console.ReadLine();

            Console.Write($"Enter grade for {studentNames[i]} (1-10): ");
            while (!int.TryParse(Console.ReadLine(), out grades[i]) || grades[i] < 1 || grades[i] > 10)
            {
                Console.Write($"Invalid input. Please enter a valid grade (1-10) for {studentNames[i]}: ");
            }
        }

        Console.WriteLine("\nStudent Grades:");
        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"{studentNames[i]}: {grades[i]}");
        }

        double average = CalculateAverage(grades);
        Console.WriteLine($"\nAverage Grade: {average:F2}");
    }

    static double CalculateAverage(int[] grades)
    {
        int sum = 0;
        foreach (int grade in grades)
        {
            sum += grade;
        }
        return (double)sum / grades.Length;
    }
}