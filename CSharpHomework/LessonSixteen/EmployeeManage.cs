using System;

class Employee
{
    public string Name { get; set; }
    public int ID { get; set; }
    public decimal Salary { get; set; }

    public Employee(string name, int id, decimal salary)
    {
        Name = name;
        ID = id;
        Salary = salary;
    }

    public virtual decimal CalculateAnnualSalary()
    {
        return Salary * 12; 
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Annual Salary: {CalculateAnnualSalary()}";
    }
}

class FullTimeEmployee : Employee
{
    public decimal Bonus { get; set; }

    public FullTimeEmployee(string name, int id, decimal salary, decimal bonus)
        : base(name, id, salary)
    {
        Bonus = bonus;
    }

    public override decimal CalculateAnnualSalary()
    {
        return (Salary * 12) + Bonus;
    }
}

class PartTimeEmployee : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursPerWeek { get; set; }

    public PartTimeEmployee(string name, int id, decimal hourlyRate, int hoursPerWeek)
        : base(name, id, 0) // Salary not used in part-time employee, so we set zero value
    {
        HourlyRate = hourlyRate;
        HoursPerWeek = hoursPerWeek;
    }

    public override decimal CalculateAnnualSalary()
    {
        return HourlyRate * HoursPerWeek * 52; // in average we usually have 52 working weeks
    }
}

class EmployeeManage
{
    public static void Execute()
    {
        Employee emp1 = new FullTimeEmployee("Ion Hotineanu", 101, 5000, 10000);
        Employee emp2 = new PartTimeEmployee("Maria Dolgan", 102, 20, 25);

        Console.WriteLine(emp1);
        Console.WriteLine(emp2);
    }
}
