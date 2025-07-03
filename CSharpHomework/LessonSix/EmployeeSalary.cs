using System;

class EmployeeSalary
{
    public static void Execute()
    {
        string role;
        do
        {
            Console.WriteLine("Choose an employee type: Manager, Salesperson, Developer");
            role = Console.ReadLine()?.Trim();

            if (role != "Manager" && role != "Salesperson" && role != "Developer")
            {
                Console.WriteLine("Invalid role. Please choose from Manager, Salesperson, or Developer.");
            }

        } while (role != "Manager" && role != "Salesperson" && role != "Developer");

        Console.Write("Enter employee name: ");
        string name = Console.ReadLine()?.Trim();

        decimal baseSalary;
        do
        {
            Console.Write("Enter base salary: ");
            string salaryInput = Console.ReadLine();

            if (!decimal.TryParse(salaryInput, out baseSalary) || baseSalary <= 0)
            {
                Console.WriteLine("Invalid salary input. Please enter a **positive numerical value**.");
            }

        } while (baseSalary <= 0);

        decimal commissionOrBonus;
        if (role == "Salesperson")
        {
            do
            {
                Console.Write("Enter commission percentage (e.g., enter 0.10 for 10%): ");
                string commissionInput = Console.ReadLine();

                if (!decimal.TryParse(commissionInput, out commissionOrBonus) || commissionOrBonus <= 0 || commissionOrBonus > 1)
                {
                    Console.WriteLine("Invalid commission input. Please enter a **positive numerical value** between **0 and 1 inclusive**.");
                }

            } while (commissionOrBonus <= 0 || commissionOrBonus > 1);
        }
        else
        {
            do
            {
                Console.Write("Enter bonus amount: ");
                string bonusInput = Console.ReadLine();

                if (!decimal.TryParse(bonusInput, out commissionOrBonus) || commissionOrBonus <= 0)
                {
                    Console.WriteLine("Invalid bonus input. Please enter a **positive numerical value** (greater than zero, without letters or special characters).");
                }

            } while (commissionOrBonus <= 0);
        }

        var employee = (Role: role, Name: name, BaseSalary: baseSalary, CommissionOrBonus: commissionOrBonus);
        decimal salary = CalculateSalary(employee);

        Console.WriteLine($"{employee.Name} ({employee.Role}) - Salary: {salary} MDL");
    }

    static decimal CalculateSalary((string Role, string Name, decimal BaseSalary, decimal CommissionOrBonus) employee)
    {
        return employee switch
        {
            ("Manager", _, var baseSalary, var bonus) => baseSalary + bonus,
            ("Salesperson", _, var baseSalary, var commissionRate) => baseSalary + (baseSalary * commissionRate),
            ("Developer", _, var baseSalary, var bonus) => baseSalary + bonus,
            _ => throw new ArgumentException("Invalid employee type")
        };
    }

}