using System;
using System.Numerics;

public class MathOperations<T> where T : INumber<T>
{
    public T Add(T a, T b) => a + b;
    public T Subtract(T a, T b) => a - b;
    public T Multiply(T a, T b) => a * b;
    public T Divide(T a, T b)
    {
        if (b == T.Zero)
            throw new ArgumentException("Cannot divide by zero.");
        return a / b;
    }
}

class Maths
{
    public static void Execute()
    {
        var intOps = new MathOperations<int>();
        Console.WriteLine("=== Integer Operations ===");
        int a = ReadValidatedInput<int>("Enter first integer: ");
        int b = ReadValidatedInput<int>("Enter second integer: ");

        Console.WriteLine($"Add: {intOps.Add(a, b)}");
        Console.WriteLine($"Subtract: {intOps.Subtract(a, b)}");
        Console.WriteLine($"Multiply: {intOps.Multiply(a, b)}");
        try
        {
            Console.WriteLine($"Divide: {intOps.Divide(a, b)}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        var doubleOps = new MathOperations<double>();
        Console.WriteLine("\n=== Double Operations ===");
        double x = ReadValidatedInput<double>("Enter first double: ");
        double y = ReadValidatedInput<double>("Enter second double: ");

        Console.WriteLine($"Add: {doubleOps.Add(x, y)}");
        Console.WriteLine($"Subtract: {doubleOps.Subtract(x, y)}");
        Console.WriteLine($"Multiply: {doubleOps.Multiply(x, y)}");
        try
        {
            Console.WriteLine($"Divide: {doubleOps.Divide(x, y)}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static T ReadValidatedInput<T>(string prompt) where T : INumber<T>
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) &&
                T.TryParse(input, null, out var result))
                return result;

            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

}