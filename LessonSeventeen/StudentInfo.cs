using System;

class Student
{
    
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }

    public Student(string name, int age, string major)
    {
        Name = name;
        Age = age;
        Major = major;
    }

    public Student(Student other)
    {
        Name = other.Name;
        Age = other.Age;
        Major = other.Major;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Major: {Major}");
    }
}

class StudentInfo
{
    public static void Execute()
    {
        
        Student student1 = new Student("Ion Petrescu", 21, "Computer Science");

        Student student2 = new Student(student1);

        student1.Name = "Andrei Afanasii";
        student1.Age = 22;
        student1.Major = "Software Engineering";

        Console.WriteLine("Original Student:");
        student1.ShowDetails();

        Console.WriteLine("\nCopied Student:");
        student2.ShowDetails();
    }
}