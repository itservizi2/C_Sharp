using System;

class IdentifyType
{
    static void TypeIdentifier(object obj)
    {
        switch (obj)
        {
            case int i:
                Console.WriteLine($"Type: int, Value: {i}");
                break;
            case double d:
                Console.WriteLine($"Type: double, Value: {d}");
                break;
            case bool b:
                Console.WriteLine($"Type: bool, Value: {b}");
                break;
            case string s:
                Console.WriteLine($"Type: string, Value: \"{s}\"");
                break;
            default:
                Console.WriteLine("Type: Unknown");
                break;
        }
    }

    public static void Execute()
    {
        Console.Write("Enter a value: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int intValue))
            TypeIdentifier(intValue);
        else if (double.TryParse(input, out double doubleValue))
            TypeIdentifier(doubleValue);
        else if (bool.TryParse(input, out bool boolValue))
            TypeIdentifier(boolValue);
        else
            TypeIdentifier(input);
    }
}