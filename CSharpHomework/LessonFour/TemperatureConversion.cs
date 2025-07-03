using System;

class TemperatureConversion
{
    public static void Execute()

    {
        Console.Write("Enter the temperature in Celsius: ");

        if (double.TryParse(Console.ReadLine(), out double celsiusTemperature))
        {
            //(°F - 32) x 5/9 =°C
            //(°C x 9/5) + 32 =°F
            double fahrenheitTemperature = (celsiusTemperature * 9 / 5) + 32;

            Console.WriteLine($"Temperature in Fahrenheit: {fahrenheitTemperature:F2}");
        }
        else
        {
            Console.WriteLine("Please enter a valid number!");
        }
    }

}
