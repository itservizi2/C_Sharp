using System;

class StudentGrade
{
    public static void Execute()
    {
        Console.Write("Enter your test grade (1-10): ");

        if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 1 && grade <= 10)
        {
            string evaluation;

            if (grade == 10)
                evaluation = "Excellent";
            else if (grade >= 8)
                evaluation = "Good";
            else if (grade >= 5)
                evaluation = "Sufficient";
            else
                evaluation = "Fail";

            Console.WriteLine($"Your grade evaluation: {evaluation}");
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a number between 1 and 10.");
        }
    }
}
