using System;

class ArithmeticCalculatorNew
{
    public static void Execute()
    {
        int num1 = GetValidNumber("Enter first number: ");
        char operation = GetValidOperator("Enter an operator (+, -, *, /): ");
        int num2 = GetValidNumber($"Enter second number{(operation == '/' ? " (non-zero for division)" : "")}: ");

        int result;

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
                result = num1 / num2;
                break;
            default:
                Console.WriteLine("Invalid operator!");
                return;
        }

        Console.WriteLine($"Result: {result}");
    }

    private static int GetValidNumber(string prompt)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out number) && (prompt.Contains("non-zero") ? number != 0 : true))
                return number;

            Console.WriteLine("Invalid input! Please enter a valid number." +
                              (prompt.Contains("non-zero") ? " Division by zero is not allowed." : ""));
        }
    }

    private static char GetValidOperator(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input) && "+-*/".Contains(input[0]))
                return input[0];

            Console.WriteLine("Invalid operator! Please enter one of (+, -, *, /).");
        }
    }
}