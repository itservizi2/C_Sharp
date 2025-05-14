using System;

class SeasonCheck
{
    public static void Execute()
    {
        int month;
        while (true)
        {
            Console.Write("Enter a month number (1-12): ");
            if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
            {
                break; 
            }
            Console.WriteLine("Invalid input. Please enter a valid integer between 1 and 12.");
        }

        string season = month switch
        {
            1 or 2 or 12 => "Winter",
            3 or 4 or 5 => "Spring",
            6 or 7 or 8 => "Summer",
            9 or 10 or 11 => "Autumn",
            _ => "Invalid month" // This case is redundant but included for completeness
        };

        Console.WriteLine($"The season for month {month} is {season}.");
    }
}