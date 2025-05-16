using System;

class MinMax
{
    public static void Execute()
    {
        int n;
        while (true)
        {
            Console.Write("Enter the number of elements (positive integer): ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input! Please enter a positive integer.");
        }

        int[] numbers = new int[n];

        Console.WriteLine("Enter the elements:");
        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"Element {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out numbers[i]))
                {
                    break;
                }
                Console.WriteLine("Invalid input! Please enter a valid integer.");
            }
        }

        int max = numbers[0];
        int min = numbers[0];

        foreach (int num in numbers)
        {
            if (num > max) max = num;
            if (num < min) min = num;
        }

        Console.WriteLine($"\nMaximum: {max}");
        Console.WriteLine($"Minimum: {min}");
    }
}