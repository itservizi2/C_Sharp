using System;

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Circle
{
    public int Radius { get; set; }
    public Point Center { get; set; }

    public Circle(int radius, Point center)
    {
        Radius = radius;
        Center = center;
    }
}

class ValueVsReference
{
    public static void Execute()
    {
        
        Console.Write("Enter X coordinate for Point: ");
        int x = GetValidIntegerInput();

        Console.Write("Enter Y coordinate for Point: ");
        int y = GetValidIntegerInput();

        Point originalPoint = new Point(x, y);
        Point copiedPoint = originalPoint;

        Console.Write("Enter new X value for copied Point: ");
        copiedPoint.X = GetValidIntegerInput();

        Console.WriteLine($"\nOriginal Point: X = {originalPoint.X}, Y = {originalPoint.Y}");
        Console.WriteLine($"Copied Point: X = {copiedPoint.X}, Y = {copiedPoint.Y}");
        Console.WriteLine("Since 'Point' is a struct (value type), modifying the copy does not affect the original.\n");

        Console.Write("Enter Circle Radius (must be positive): ");
        int radius = GetPositiveIntegerInput();

        Console.Write("Enter X coordinate for Circle Center: ");
        int centerX = GetValidIntegerInput();

        Console.Write("Enter Y coordinate for Circle Center: ");
        int centerY = GetValidIntegerInput();

        Circle originalCircle = new Circle(radius, new Point(centerX, centerY));
        Circle referencedCircle = originalCircle;

        Console.Write("Enter new Radius value for referenced Circle (must be positive): ");
        referencedCircle.Radius = GetPositiveIntegerInput();

        Console.WriteLine($"\nOriginal Circle Radius: {originalCircle.Radius}");
        Console.WriteLine($"Referenced Circle Radius: {referencedCircle.Radius}");
        Console.WriteLine("Since 'Circle' is a class (reference type), modifying the reference affects the original object.");
    }

    static int GetValidIntegerInput()
    {
        int value;
        while (true)
        {
            Console.Write("Enter a valid integer: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out value))
            {
                return value;
            }
            Console.WriteLine("Error: Please enter a valid integer.");
        }
    }

    static int GetPositiveIntegerInput()
    {
        int value;
        while (true)
        {
            Console.Write("Enter a positive integer: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out value) && value > 0)
            {
                return value;
            }
            Console.WriteLine("Error: Please enter a positive integer.");
        }
    }
}
