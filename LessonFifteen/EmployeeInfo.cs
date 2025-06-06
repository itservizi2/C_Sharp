using System;

class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }

    public Employee(string name, decimal salary, string department)
    {
        Name = name;
        Salary = salary;
        Department = department;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Name: {Name}, Salary: {Salary:C}, Department: {Department}");
    }
}

class EmployeeInfo
{
    public static void Execute()
    {
        Employee emp1 = new Employee("Petre Marinescu", 55000, "IT");
        Employee emp2 = new Employee("Ion Ababii", 60000, "HR");
        Employee emp3 = new Employee("Maria Dragan", 45000, "Finance");

        emp1.ShowDetails();
        emp2.ShowDetails();
        emp3.ShowDetails();
    }
}