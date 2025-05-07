using System;

class BodyMassIndex
{
    public static void Execute()
    {
        Console.Write("Enter your weight in kg: ");

        if (double.TryParse(Console.ReadLine(), out double weight))
        {

            Console.Write("Enter your height in meters using a separator: ");

            if (double.TryParse(Console.ReadLine(), out double height) && height > 0)
            {
                // Body mass index formula: BMI = weight / (height * height)
                double bmi = weight / (height * height);

                Console.WriteLine($"Your BMI is: {bmi:F2}");
            }
            else
            {
                Console.WriteLine("Please enter a valid positive height!");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid weight!");
        }
    }
}

