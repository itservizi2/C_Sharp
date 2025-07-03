using System;

class Employee
{
    public string Name { get; set; }

    public Employee(string name)
    {
        Name = name;
    }

    public virtual void ShowDetails()
    {
        Console.WriteLine($"Employee Name: {Name}");
    }
}

class Manager : Employee
{
    public string Department { get; set; }

    public Manager(string name, string department) : base(name)
    {
        Department = department;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"Manager Name: {Name}, Department: {Department}");
    }
}

class EmployeeInfo
{
    public static void Execute()
    {
        
        Manager manager = new Manager("Petrov Vasile", "IT");

        manager.ShowDetails();
    }
}