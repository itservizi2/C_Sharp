using System;
using System.Collections.Generic;

class Stack<T>
{
    private List<T> items = new List<T>();

    public int Count { get; internal set; }

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        T topItem = items[^1];
        items.RemoveAt(items.Count - 1);
        return topItem;
    }

    public T Peek()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        return items[^1];
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public void DisplayStack()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Stack is empty.");
            return;
        }

        Console.WriteLine("Stack elements:");
        for (int i = items.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(items[i]);
        }
    }
}

class PushPopPeek
{
    public static void Execute()
    {
        Stack<int> stack = new Stack<int>();

        while (true)
        {
            Console.WriteLine("\nStack Operations:");
            Console.WriteLine("1. Push");
            Console.WriteLine("2. Pop");
            Console.WriteLine("3. Peek");
            Console.WriteLine("4. Check if Empty");
            Console.WriteLine("5. Display Stack");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            string input = GetValidatedInput();

            if (int.TryParse(input, out int choice))
            {
                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter value to push: ");
                            string valueInput = GetValidatedInput();
                            if (int.TryParse(valueInput, out int value))
                            {
                                stack.Push(value);
                                Console.WriteLine($"{value} added to the stack.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a number.");
                            }
                            break;
                        case 2:
                            Console.WriteLine($"Popped: {stack.Pop()}");
                            break;
                        case 3:
                            Console.WriteLine($"Peek: {stack.Peek()}");
                            break;
                        case 4:
                            Console.WriteLine(stack.IsEmpty() ? "Stack is empty." : "Stack is not empty.");
                            break;
                        case 5:
                            stack.DisplayStack();
                            break;
                        case 6:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
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