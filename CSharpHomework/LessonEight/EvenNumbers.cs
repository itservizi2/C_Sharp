using System;

class EvenNumbers
{
    public static void Execute()
    {
        int start = GetValidNumber("Enter the starting number: ");
        int end = GetValidNumber("Enter the ending number: ");

        Console.WriteLine("\nEven numbers in the range:");

        for (int i = start; i <= end; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }

    static int GetValidNumber(string prompt)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine(); 

            if (string.IsNullOrWhiteSpace(input)) 
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }

            if (int.TryParse(input, out number))
            {
                return number;
            }

            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}