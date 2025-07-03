using System;

class TriangleClassifier
{
    public static void Execute()
    {
        Console.WriteLine("Enter the lengths of the three sides of the triangle:");

        double a = GetPositiveNumber("Side a: ");
        double b = GetPositiveNumber("Side b: ");
        double c = GetPositiveNumber("Side c: ");

        if (IsValidTriangle(a, b, c))
        {
            Console.WriteLine($"The triangle is {ClassifyTriangle(a, b, c)}.");
        }
        else
        {
            Console.WriteLine("Invalid triangle: The sides do not satisfy the triangle inequality rule.");
        }
    }

    static double GetPositiveNumber(string prompt)
    {
        double number;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out number) && number > 0)
            {
                return number;
            }
            Console.WriteLine("Invalid input: Please enter a positive numeric value.");
        }
    }

    static bool IsValidTriangle(double a, double b, double c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }

    static string ClassifyTriangle(double a, double b, double c)
    {
        if (a == b && b == c)
        {
            return "Equilateral";
        }
        else if (a == b || a == c || b == c)
        {
            return "Isosceles";
        }
        else
        {
            return "Scalene";
        }
    }
}