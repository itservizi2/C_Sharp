using System;

class UntilZero
{
    public static void Execute()
    {
        int number;

        Console.WriteLine("Enter numbers (enter 0 to stop):");

        while (true)
        {
            Console.Write("Enter a number: ");
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }

            if (number == 0)
            {
                Console.WriteLine("Program terminated. You entered 0.");
                break;
            }
            else
            {
                Console.WriteLine($"You entered: {number}");
            }
        }
    }
}
