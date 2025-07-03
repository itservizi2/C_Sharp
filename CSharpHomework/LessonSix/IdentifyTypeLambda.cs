using System;
using System.ComponentModel;

class IdentifyTypeLambda
{
    static readonly Action<object> TypeIdentifier = obj => Console.WriteLine(obj switch
    //In C#, readonly is a modifier used for fields. It ensures that a field can only be assigned:
    //-At the time of declaration(when defining the field).
    //- Inside the constructor of the class (for instance fields)
    //Removing readonly means any part of the program could overwrite TypeIdentifier, potentially introducing unintended behavior.

    {
        int i => $"Type: int, Value: {i}",
        double d => $"Type: double, Value: {d}",
        bool b => $"Type: bool, Value: {b}",
        string s => $"Type: string, Value: \"{s}\"",
        _ => "Type: Unknown"
    });

    public static void Execute()
    {
        Console.Write("Enter a value: ");
        string input = Console.ReadLine() ?? ""; // Make sure that user does not input null

        TypeIdentifier(
            int.TryParse(input, out int intValue) ? intValue :
            double.TryParse(input, out double doubleValue) ? doubleValue :
            bool.TryParse(input, out bool boolValue) ? boolValue :
            input
        );
    }
}
