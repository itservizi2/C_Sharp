using System;

public class MathOperations
{
    public int Add(int a, int b) => a + b;

    public double Add(double a, double b) => a + b;
}

public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea() => Math.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea() => Width * Height;
}

public class MathCalculator
{

    public static void Execute()
    {
        MathOperations mathOps = new MathOperations();

        Console.WriteLine("Enter two positive integers:");
        int intNum1 = GetPositiveInteger();
        int intNum2 = GetPositiveInteger();
        Console.WriteLine($"Addition of integers: {mathOps.Add(intNum1, intNum2)}");

        Console.WriteLine("Enter two positive doubles:");
        double doubleNum1 = GetPositiveDouble();
        double doubleNum2 = GetPositiveDouble();
        Console.WriteLine($"Addition of doubles: {mathOps.Add(doubleNum1, doubleNum2)}");

        Console.WriteLine("Enter a positive radius for the circle:");
        double radius = GetPositiveDouble();
        Shape circle = new Circle(radius);
        Console.WriteLine($"Area of Circle: {circle.CalculateArea()}");

        Console.WriteLine("Enter positive width and height for the rectangle:");
        double width = GetPositiveDouble();
        double height = GetPositiveDouble();
        Shape rectangle = new Rectangle(width, height);
        Console.WriteLine($"Area of Rectangle: {rectangle.CalculateArea()}");
    }

    private static int GetPositiveInteger()
    {
        int value;
        while (true)
        {
            Console.Write("Enter a positive integer: ");
            if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                return value;
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    private static double GetPositiveDouble()
    {
        double value;
        while (true)
        {
            Console.Write("Enter a positive number: ");
            if (double.TryParse(Console.ReadLine(), out value) && value > 0)
                return value;
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
    }
}