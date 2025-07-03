using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueue<T>
{
    private class PriorityQueueItem
    {
        public T Item { get; }
        public int Priority { get; }

        public PriorityQueueItem(T item, int priority)
        {
            Item = item;
            Priority = priority;
        }
    }

    private readonly List<PriorityQueueItem> _items = new();

    public void Enqueue(T item, int priority)
    {
        _items.Add(new PriorityQueueItem(item, priority));
    }

    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty.");

        int highestPriority = _items.Max(i => i.Priority);
        var item = _items.First(i => i.Priority == highestPriority);
        _items.Remove(item);
        return item.Item;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty.");

        int highestPriority = _items.Max(i => i.Priority);
        return _items.First(i => i.Priority == highestPriority).Item;
    }

    public bool IsEmpty() => !_items.Any();
}

class PriorityQueue
{
    public static void Execute()
    {
        var queue = new PriorityQueue<string>();

        Console.WriteLine("Priority Queue Input (type 'done' to finish adding items):");

        while (true)
        {
            Console.Write("Enter an item: ");
            string? rawInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(rawInput))
            {
                Console.WriteLine("Item cannot be empty. Try again.");
                continue;
            }

            if (rawInput.Trim().ToLower() == "done")
                break;

            string item = rawInput.Trim();

            Console.Write("Enter priority (integer): ");
            string? priorityInput = Console.ReadLine();

            if (!int.TryParse(priorityInput, out int priority))
            {
                Console.WriteLine("Invalid priority. Must be an integer.");
                continue;
            }

            queue.Enqueue(item, priority);
            Console.WriteLine($"Added: \"{item}\" with priority {priority}\n");
        }

        Console.WriteLine("\nProcessing items by priority:");
        while (!queue.IsEmpty())
        {
            Console.WriteLine($"Dequeued: {queue.Dequeue()}");
        }

        Console.WriteLine("\nAll items processed.");
    }
}