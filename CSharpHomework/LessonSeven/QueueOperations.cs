using System;
using System.Collections.Generic;

class QueueOperations
{
    static Queue<int> queue = new Queue<int>();

    public static void Execute()
    {
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Enqueue");
            Console.WriteLine("2. Dequeue");
            Console.WriteLine("3. Peek");
            Console.WriteLine("4. Display Queue");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = GetValidatedInput();
            switch (choice)
            {
                case "1":
                    Enqueue();
                    break;
                case "2":
                    Dequeue();
                    break;
                case "3":
                    Peek();
                    break;
                case "4":
                    DisplayQueue();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void Enqueue()
    {
        while (true)
        {
            Console.Write("Enter a value to enqueue: ");
            string input = GetValidatedInput();
            if (int.TryParse(input, out int value))
            {
                queue.Enqueue(value);
                Console.WriteLine($"{value} added to the queue.");
                break;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static void Dequeue()
    {
        if (queue.Count > 0)
        {
            int removedValue = queue.Dequeue();
            Console.WriteLine($"Dequeued: {removedValue}");
        }
        else
        {
            Console.WriteLine("Queue is empty.");
        }
    }

    static void Peek()
    {
        if (queue.Count > 0)
        {
            Console.WriteLine($"Front of queue: {queue.Peek()}");
        }
        else
        {
            Console.WriteLine("Queue is empty.");
        }
    }

    static void DisplayQueue()
    {
        if (queue.Count > 0)
        {
            Console.WriteLine("Queue contents:");
            foreach (int item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Queue is empty.");
        }
    }

    private static string GetValidatedInput()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            Console.WriteLine("Invalid input! Please enter a valid value.");
        }
    }
}