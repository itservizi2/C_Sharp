using System;
using System.Collections.Generic;

struct Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Occupation { get; set; }

    public Person(string name, int age, string occupation)
    {
        Name = name ?? string.Empty;
        Age = age;
        Occupation = occupation ?? string.Empty;
    }
}

class PersonInfo
{
    public static void Execute()
    {
        List<Person> people = new List<Person>();

        Console.WriteLine("Enter details for people (type 'done' when finished):");
        while (true)
        {
            Console.Write("Enter name (or 'done' to finish): ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name) || name.Equals("done", StringComparison.OrdinalIgnoreCase))
                break;

            int age;
            while (true)
            {
                Console.Write("Enter age (must be a positive integer): ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                    break;

                Console.WriteLine("Invalid input. Please enter a **positive** integer.");
            }

            Console.Write("Enter occupation: ");
            string? occupation = Console.ReadLine();

            people.Add(new Person(name ?? string.Empty, age, occupation ?? string.Empty));
        }

        Console.WriteLine("\nList of people:");
        foreach (var person in people)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Occupation: {person.Occupation}");
        }

        Console.Write("\nEnter an occupation to filter by: ");
        string? referenceOccupation = Console.ReadLine();
        referenceOccupation = referenceOccupation ?? string.Empty;

        Console.WriteLine("\nPeople with the occupation \"" + referenceOccupation + "\":");
        foreach (var person in people)
        {
            if (person.Occupation.Equals(referenceOccupation, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }
        }
    }
}