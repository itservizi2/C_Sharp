using System;

class ArithmeticCalculator
{
    public static void Execute()
    {
        int num1 = GetValidNumber("Enter first number: ");
        int num2;
        char operation = GetValidOperator("Enter an operator (+, -, *, /): ");

        if (operation == '/')
        {
            num2 = GetValidNonZeroNumber("Enter second number (non-zero for division): ");
        }
        else
        {
            num2 = GetValidNumber("Enter second number: ");
        }

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
            if (int.TryParse(input, out number))
                return number;

            Console.WriteLine("Invalid input! Please enter a valid number.");
        }
    }

    private static int GetValidNonZeroNumber(string prompt)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out number) && number != 0)
                return number;

            Console.WriteLine("Error: Division by zero is not allowed. Please enter a non-zero number.");
        }
    }

    private static char GetValidOperator(string prompt)
    {
        char operation;
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