using System;

class Reverse
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
            Console.WriteLine("Invalid input. Please enter a positive numerical value.");
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
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        Console.WriteLine("Reversed array:");
        for (int i = n - 1; i >= 0; i--)
        {
            Console.Write(numbers[i] + " ");
        }
    }
}
