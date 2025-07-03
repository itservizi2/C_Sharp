using System;
using System.Collections.Generic;

class InvalidGradeException : Exception
{
    public InvalidGradeException(string message) : base(message) { }
}

class GradeAverage
{
    public static void Execute()
    {
        List<double> grades = new List<double>();
        const int gradeCount = 4;

        Console.WriteLine($"Enter {gradeCount} grades (1-10):");

        for (int i = 0; i < gradeCount; i++)
        {
            Console.Write($"Grade {i + 1}: ");
            try
            {
                double grade = Convert.ToDouble(Console.ReadLine());

                if (grade < 1 || grade > 10)
                {
                    throw new InvalidGradeException("Grade must be between 1 and 10.");
                }

                grades.Add(grade);
            }
            catch (InvalidGradeException ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}");
                i--; 
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input: Please enter a numeric value.");
                i--; 
            }
        }

        double average = CalculateAverage(grades);
        Console.WriteLine($"\nThe average grade is: {average:F2}");
    }

    static double CalculateAverage(List<double> grades)
    {
        double sum = 0;
        foreach (double grade in grades)
        {
            sum += grade;
        }
        return sum / grades.Count;
    }
}