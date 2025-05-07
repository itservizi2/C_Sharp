using System;

class SimpleCalculator
{
    public static void Execute()
    {
        
        Console.Write("Enter the first number: ");
        if (!double.TryParse(Console.ReadLine(), out double num1))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        Console.Write("Enter the second number: ");
        if (!double.TryParse(Console.ReadLine(), out double num2))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        Console.Write("Enter an operation (+, -, *, /, ^): ");
        char operation = Console.ReadKey().KeyChar;
        Console.WriteLine(); 

        double result;
        switch (operation)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                if (num2 == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    return;
                }
                result = num1 / num2;
                break;
            case '^':
                result = Math.Pow(num1, num2);
                break;
            default:
                Console.WriteLine("Invalid operation. Please enter a valid operator (+, -, *, /, ^).");
                return;
        }

        Console.WriteLine($"Result: {num1} {operation} {num2} = {result:F2}");
    }
}
