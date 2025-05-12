using System;

class BirthDate
{
    public static void Execute()
    {
        Console.WriteLine("Enter your birth date:");

        int day = GetValidatedInput("Day (1-31): ", 1, 31);
        int month = GetValidatedInput("Month (1-12): ", 1, 12);
        int year = GetValidatedInput("Year (1850 - current year): ", 1850, DateTime.Now.Year);

        DateTime birthDate = new DateTime(year, month, day);
        DateTime currentDate = DateTime.Now;

        int age = currentDate.Year - birthDate.Year;

        // correction in case birthday did not happen yet in this year
        if (currentDate < birthDate.AddYears(age))
        {
            age--;
        }

        Console.WriteLine($"You are {age} years old.");
    }

    static int GetValidatedInput(string prompt, int min, int max)
    {
        int value;
        do
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
            {
                return value;
            }
            Console.WriteLine($"Invalid input. Please enter a value between {min} and {max}.");
        } while (true);
    }
}