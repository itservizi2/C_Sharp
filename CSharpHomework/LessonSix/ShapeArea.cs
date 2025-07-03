using System;

class ShapeArea
{
    public static void Execute()
    {
        Console.WriteLine("Choose a shape to calculate the area:");
        Console.WriteLine("1 - Circle\n2 - Rectangle\n3 - Triangle");

        int choice;
        while (true)
        {
            Console.Write("Enter choice (1-3): ");
            choice = GetPositiveIntegerInput();

            if (choice >= 1 && choice <= 3)
                break;

            Console.WriteLine("Invalid choice! Please enter a number between 1 and 3.");
        }

        object shape = choice switch
        {
            1 => GetCircle(),
            2 => GetRectangle(),
            3 => GetTriangle(),
            _ => throw new ArgumentException("Invalid choice") 
        };

        Console.WriteLine($"Area: {CalculateArea(shape):F2}");
    }

    static (string, double) GetCircle()
    {
        Console.Write("Enter the radius: ");
        double radius = GetPositiveDoubleInput();
        return ("Circle", radius);
    }

    static (string, double, double) GetRectangle()
    {
        Console.Write("Enter the width: ");
        double width = GetPositiveDoubleInput();
        Console.Write("Enter the height: ");
        double height = GetPositiveDoubleInput();
        return ("Rectangle", width, height);
    }

    static (string, double, double) GetTriangle()
    {
        Console.Write("Enter the base length: ");
        double baseLength = GetPositiveDoubleInput();
        Console.Write("Enter the height: ");
        double height = GetPositiveDoubleInput();
        return ("Triangle", baseLength, height);
    }

    static double CalculateArea(object shape) =>
        shape switch
        {
            ("Circle", double radius) => Math.PI * Math.Pow(radius, 2),
            ("Rectangle", double width, double height) => width * height,
            ("Triangle", double baseLength, double height) => 0.5 * baseLength * height,
            _ => throw new ArgumentException("Unknown shape")
        };

    static double GetPositiveDoubleInput()
    {
        double value;
        while (true)
        {
            string input = Console.ReadLine();
            if (double.TryParse(input, out value) && value > 0)
                return value;

            Console.Write("Invalid input! Please enter a positive number: ");
        }
    }

    static int GetPositiveIntegerInput()
    {
        int value;
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out value) && value > 0)
                return value;

            Console.Write("Invalid input! Please enter a positive integer: ");
        }
    }
}