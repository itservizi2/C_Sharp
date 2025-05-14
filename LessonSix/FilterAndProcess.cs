using System;
using System.Collections.Generic;

class FilterAndProcess
{
    public static void Execute()
    {
        List<object> objects = new List<object>();

        Console.WriteLine("Enter values (type 'exit' to stop):");

        while (true)
        {
            string input = Console.ReadLine();
            if (input?.ToLower() == "exit")
                break;

            if (int.TryParse(input, out int number))
            {
                objects.Add(number);
            }
            else
            {
                objects.Add(input);
            }
        }

        Console.WriteLine("\nProcessing values:");
        foreach (var obj in objects)
        {
            ProcessObject(obj);
        }
    }

    static void ProcessObject(object obj)
    {
        switch (obj)
        {
            case int number when number % 2 == 0:
                Console.WriteLine($"Even number: {number}");
                break;
            case int number:
                Console.WriteLine($"Odd number: {number}");
                break;
            case string text when text.Length > 5:
                Console.WriteLine($"Long string: {text}");
                break;
            case string text:
                Console.WriteLine($"Short string: {text}");
                break;
            default:
                Console.WriteLine($"Unknown object: {obj}");
                break;
        }
    }
}