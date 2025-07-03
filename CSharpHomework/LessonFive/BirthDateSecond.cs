using System;

class BirthDateSecond
{
    public static void Execute()
    {
        Console.WriteLine("Enter your birth date (dd/MM/yyyy):");

        DateTime birthDate;
        while (true)
        {
            string input = Console.ReadLine();

            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out birthDate))
            {
                break;
            }

            Console.WriteLine("Invalid format. Please enter your birth date in the format dd/MM/yyyy.");
        }

        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - birthDate.Year;

        // Correct age if birthday hasn't happened yet this year
        if (currentDate < birthDate.AddYears(age))
        {
            age--;
        }

        Console.WriteLine($"You are {age} years old.");
    }
}
