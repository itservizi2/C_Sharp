using System;

class EmployeeSalary
{
    public static void Execute()
    {
        
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();

        Console.Write("Enter gross salary (local currency): ");
        if (!float.TryParse(Console.ReadLine(), out float grossSalary) || grossSalary < 0)
        {
            Console.WriteLine("Invalid salary input.");
            return;
        }

        Console.Write("Enter exchange rate to USD: 1 USD = ...MDL ");
        if (!double.TryParse(Console.ReadLine(), out double exchangeRate) || exchangeRate <= 0)
        {
            Console.WriteLine("Invalid exchange rate input.");
            return;
        }

        Console.Write("Enter tax bracket (1 for 10%, 2 for 20%, or 3 for 30%) :  ");
        if (!int.TryParse(Console.ReadLine(), out int taxBracket) || taxBracket < 1 || taxBracket > 3)
        {
            Console.WriteLine("Invalid tax bracket. Must be 1, 2, or 3.");
            return;
        }

        float taxPercentage = taxBracket switch
        {
            1 => 0.10f,
            2 => 0.20f,
            3 => 0.30f,
            _ => 0f 
        };

        float netSalaryLocal = grossSalary * (1 - taxPercentage);

        double netSalaryUSD = (double)netSalaryLocal / exchangeRate;

        string salaryComparison = netSalaryUSD > 2000 ? "Salary is above average." : "Salary is below average.";

        Console.WriteLine($"\nEmployee: {name}");
        Console.WriteLine($"Net salary (local currency): {netSalaryLocal:F2}");
        Console.WriteLine($"Net salary (USD): {netSalaryUSD:F2}");
        Console.WriteLine(salaryComparison);
    }
}