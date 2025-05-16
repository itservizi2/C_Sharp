using System;

struct Employee
{
    public string Name;
    public string Department;
    public double Salary;
}

class EmployeeInfo
{
    public static void Execute()
    {
        Employee[] employees = new Employee[3];

        for (int i = 0; i < employees.Length; i++)
        {
            Console.Write($"Enter name of employee {i + 1}: ");
            employees[i].Name = Console.ReadLine();

            Console.Write($"Enter department of employee {i + 1}: ");
            employees[i].Department = Console.ReadLine();

            while (true)
            {
                Console.Write($"Enter salary of employee {i + 1} (positive number): ");
                if (double.TryParse(Console.ReadLine(), out double salary) && salary > 0)
                {
                    employees[i].Salary = salary;
                    break;
                }
                Console.WriteLine("Invalid input! Salary must be a positive numerical value.");
            }
        }

        double totalSalary = 0;
        foreach (var employee in employees)
        {
            totalSalary += employee.Salary;
        }
        double averageSalary = totalSalary / employees.Length;

        Console.WriteLine($"\nAverage Salary: {averageSalary:F2}");

        Console.WriteLine("\nEmployees with a salary higher than the average:");
        foreach (var employee in employees)
        {
            if (employee.Salary > averageSalary)
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}