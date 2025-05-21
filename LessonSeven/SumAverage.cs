using System;

class SumAverage
{
    public static void Execute()
    {
        int size;

        while (true)
        {
            Console.Write("Enter the size of the array (positive integer): ");
            if (int.TryParse(Console.ReadLine(), out size) && size > 0)
                break;
            Console.WriteLine("Invalid input! Please enter a positive integer.");
        }

        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            while (true)
            {
                Console.Write($"Enter integer {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out numbers[i]))
                    break;
                Console.WriteLine("Invalid input! Please enter an integer.");
            }
        }

        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        double average = (double)sum / size;

        Console.WriteLine($"\nSum: {sum}");
        Console.WriteLine($"Average: {average:F2}");
    }
}
